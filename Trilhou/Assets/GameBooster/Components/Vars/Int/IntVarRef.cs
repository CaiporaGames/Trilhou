using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameBooster{
	
	[System.Serializable]
	public class GlobalVarGetEventsInt : GlobalVarGetEvents<int>{
		public IntUnityEvent onValueChange;
		public StringUnityEvent onValueChangeText;
	}

	[Comment(
@"Reference to a IntVar

Related components:
	IntVar

Methods:
	void Add(int inc)
	void Multiply(int multiplier)
	void Divide(int divider)
	void SetValue(int value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#intvarref")]
	[AddComponentMenu("GameBooster/GlobalVar/Int/IntVarRef")]
	public class IntVarRef : GlobalVarRef<int,GlobalVarGetEventsInt,IntVar> {
		
		public override void CallEvent (int newValue) {
			getValue.onValueChange.Invoke (newValue);
			getValue.onValueChangeText.Invoke (newValue.ToString ());
		}

		public void Add(int inc){
			if (m_globalVar) {
				m_globalVar.Add (inc);
			}
		}
		public void Multiply(int multiplier){
			if (m_globalVar) {
				m_globalVar.Multiply (multiplier);
			}
		}
		public void Divide(int divider){
			if (m_globalVar) {
				m_globalVar.Divide (divider);
			}
		}

	}
}