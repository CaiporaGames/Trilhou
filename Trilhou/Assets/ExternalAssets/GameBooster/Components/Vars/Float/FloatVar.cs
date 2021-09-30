using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"Stores a global float variable

Related components:
	FloatVarRef

Methods:
	void Add(float inc)
	void Multiply(float multiplier)
	void Divide(float divider)
	void SetValue(float value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#floatvar")]
	[AddComponentMenu("GameBooster/GlobalVar/Float/FloatVar")]
	public class FloatVar : GlobalVar<float> {

		protected override void LoadFromPlayerPrefsImplementation () {
			PlayerPrefs.SetFloat (playerPrefsKey, m_value);
		}

		protected override void SaveOnPlayerPrefsImplementation () {
			m_value = PlayerPrefs.GetFloat (playerPrefsKey);
		}

		public void Add(float inc){
			SetValue (value + inc);
		}
		public void Multiply(float multiplier){
			SetValue (value * multiplier);
		}
		public void Divide(float divider){
			SetValue (value / divider);
		}

	}
}