using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GameBooster{

	[System.Serializable]
	public class GlobalVarGetEventsFloat : GlobalVarGetEvents<float>{
		public FloatUnityEvent onValueChange;
		public string stringFormat;
		public StringUnityEvent onValueChangeText;
	}

	[Comment(
@"Reference to a FloatVar

Related components:
	FloatVar

Methods:
	void Add(float inc)
	void Multiply(float multiplier)
	void Divide(float divider)
	void SetValue(float value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#floatvarref")]
	[AddComponentMenu("GameBooster/GlobalVar/Float/FloatVarRef")]
	public class FloatVarRef : GlobalVarRef<float,GlobalVarGetEventsFloat,FloatVar> {

		public override void CallEvent (float newValue) {
			getValue.onValueChange.Invoke (newValue);

			if (string.IsNullOrEmpty (getValue.stringFormat)) {
				getValue.onValueChangeText.Invoke (newValue.ToString ());
			} else {
				getValue.onValueChangeText.Invoke (newValue.ToString (getValue.stringFormat));
			}
		}

		public void Add(float inc){
			if (m_globalVar) {
				m_globalVar.Add (inc);
			}
		}
		public void Multiply(float multiplier){
			if (m_globalVar) {
				m_globalVar.Multiply (multiplier);
			}
		}
		public void Divide(float divider){
			if (m_globalVar) {
				m_globalVar.Divide (divider);
			}
		}

	}
}