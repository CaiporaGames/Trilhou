using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameBooster{

	public class GlobalVarGetEvents<T>{
		
		[SerializeField]
		public bool condition;

		[ConditionalHideAttribute("condition")]
		public bool ignoreConditionOnStart = true;

		[ConditionalHideAttribute("condition")]
		public GlobalVarComparisonType comparison;

		[ConditionalHideAttribute("condition")]
		public T comparisonValue;
	}

	public abstract class GlobalVarRef<T,TE,GlobalVarT> : GameBoosterBehaviour where T:System.IComparable where TE : GlobalVarGetEvents<T> where GlobalVarT : GlobalVar<T> {
		
		public string varId;

		protected GlobalVarT m_globalVar;

		public GlobalVariablePlace varPlace;

		public TE getValue;

		void OnEnable(){
			if (!m_globalVar) {
				m_globalVar = (GlobalVarT)GlobalVarUtils.FindGlobalVar<T>(transform, varPlace, varId);
			}
			if (m_globalVar) {
				m_globalVar.onValueChange += CheckConditions;
			}
		}

		void OnDisable(){
			if (m_globalVar) {
				m_globalVar.onValueChange -= CheckConditions;
			}
		}

		bool IsConditionTrue(T newValue){
			int comp = newValue.CompareTo (getValue.comparisonValue);
			switch (getValue.comparison) {
			case GlobalVarComparisonType.Equals:
				return comp == 0;
			case GlobalVarComparisonType.NotEquals:
				return comp != 0;
			case GlobalVarComparisonType.LessThan:
				return comp < 0;
			case GlobalVarComparisonType.LessOrEqualTo:
				return comp <= 0;
			case GlobalVarComparisonType.GreaterThan:
				return comp > 0;
			case GlobalVarComparisonType.GreaterOrEqualTo:
				return comp >= 0;
			}
			return false;
		}

		void CheckConditions(T newValue, bool starting){
			if (getValue.condition) {
				if (IsConditionTrue (newValue) || (starting && getValue.ignoreConditionOnStart)) {
					CallEvent(newValue);
				}
			} else {
				CallEvent(newValue);
			}
		}

		public abstract void CallEvent(T newValue);


		public void SetValue(T newValue){
			if (m_globalVar) {
				m_globalVar.SetValue (newValue);
			}
		}
		public void ResetValue(){
			if (m_globalVar) {
				m_globalVar.ResetValue ();
			}
		}

		public void SaveOnPlayerPrefs(){
			if (m_globalVar) {
				m_globalVar.SaveOnPlayerPrefs ();
			}
		}
		public void LoadFromPlayerPrefs(){
			if (m_globalVar) {
				m_globalVar.LoadFromPlayerPrefs ();
			}
		}

	}

}