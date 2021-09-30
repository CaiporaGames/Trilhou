using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameBooster{
	
	public enum GlobalVariablePlace{ Anywhere, Self, Children, Parent }

	public enum GlobalVarComparisonType { Equals, NotEquals, LessThan, LessOrEqualTo, GreaterThan, GreaterOrEqualTo }

	public abstract class GlobalVar<T> : GameBoosterBehaviour where T:System.IComparable{

		[Tooltip("Var identifier")]
		public string id;

		[SerializeField]
		protected T m_value;

		public T value { get { return this.m_value; } set { SetValue (value); } }

		public T startValue;

		public enum FilterType { None, KeepMinValue, KeepMaxValue }
		public FilterType filter;

		public bool limitValue;
		[ConditionalHideAttribute("limitValue")]
		public T minValue;
		[ConditionalHideAttribute("limitValue")]
		public T maxValue;

		public bool storeOnPlayerPrefs;

		[ConditionalHideAttribute("storeOnPlayerPrefs")]
		public string playerPrefsKey;

		[ConditionalHideAttribute("storeOnPlayerPrefs")]
		public bool autoLoadOnStart;

		[ConditionalHideAttribute("storeOnPlayerPrefs")]
		public bool autoSave;

		protected bool canSendOnValueChange;
		public event System.Action<T,bool> onValueChange;

		void Start(){
			
			canSendOnValueChange = false;

			if (storeOnPlayerPrefs && autoLoadOnStart) {
				LoadFromPlayerPrefs ();
			} else {
				SetValue (startValue);
			}

			if (onValueChange != null) {
				onValueChange.Invoke (m_value,true);
			}

			canSendOnValueChange = true;
		}

		public void SetValue(T newValue){
			
			if (newValue.CompareTo(m_value) != 0) {

				m_value = newValue;

				if (storeOnPlayerPrefs && autoSave) {
					SaveOnPlayerPrefs ();
				}

				if (onValueChange != null && canSendOnValueChange) {
					onValueChange.Invoke (newValue,false);
				}
			}
		}

		public void ResetValue(){
			SetValue (startValue);
		}

		public void SaveOnPlayerPrefs(){
			if (storeOnPlayerPrefs && !string.IsNullOrEmpty (playerPrefsKey)) {
				SaveOnPlayerPrefsImplementation();
			}
		}
		public void LoadFromPlayerPrefs(){
			if (storeOnPlayerPrefs && !string.IsNullOrEmpty (playerPrefsKey)) {
				if (PlayerPrefs.HasKey (playerPrefsKey)) {
					LoadFromPlayerPrefsImplementation ();
				}
			}
		}

		protected abstract void SaveOnPlayerPrefsImplementation();
		protected abstract void LoadFromPlayerPrefsImplementation();

	}

	public sealed class GlobalVarUtils{
		
		public static GlobalVar<T> FindGlobalVar<T>(Transform origin, GlobalVariablePlace varPlace, string globalVarId) where T : System.IComparable {
			switch (varPlace) {
			case GlobalVariablePlace.Anywhere:
				return GameObject.FindObjectsOfType<GlobalVar<T>> ().Where (e => e.id == globalVarId).FirstOrDefault ();
			case GlobalVariablePlace.Children:
				return origin.GetComponentsInChildren<GlobalVar<T>> ().Where (e => e.id == globalVarId).FirstOrDefault ();
			case GlobalVariablePlace.Parent:
				return origin.GetComponentsInParent<GlobalVar<T>> ().Where (e => e.id == globalVarId).FirstOrDefault ();
			case GlobalVariablePlace.Self:
				return origin.GetComponents<GlobalVar<T>> ().Where (e => e.id == globalVarId).FirstOrDefault ();	
			}
			return null;
		}

	}




}