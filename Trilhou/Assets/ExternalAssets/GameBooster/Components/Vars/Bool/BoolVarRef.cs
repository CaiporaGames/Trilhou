using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameBooster{

	[System.Serializable]
	public class GlobalVarGetEventsBool : GlobalVarGetEvents<bool>{
		public BoolUnityEvent onValueChange;

		public string falseText = "No";
		public string trueText = "Yes";
		public StringUnityEvent onValueChangeText;
	}

	[Comment(
		@"Reference to a BoolVar

Related components:
	BoolVar

Methods:
	void Or(bool value)
	void And(bool value)
	void Neg()
	void SetValue(bool value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#boolvarref")]
	[AddComponentMenu("GameBooster/GlobalVar/Bool/BoolVarRef")]
	public class BoolVarRef : GlobalVarRef<bool,GlobalVarGetEventsBool,BoolVar> {

		public override void CallEvent (bool newValue) {
			getValue.onValueChange.Invoke (newValue);
			getValue.onValueChangeText.Invoke (newValue ? getValue.trueText : getValue.falseText);
		}

		public void Or(bool value){
			if (m_globalVar) {
				m_globalVar.Or (value);
			}
		}
		public void And(bool value){
			if (m_globalVar) {
				m_globalVar.And (value);
			}
		}
		public void Neg(){
			if (m_globalVar) {
				m_globalVar.Neg ();
			}
		}

	}
}