using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{
	
	[Comment(
@"Stores a global int variable

Related components:
	IntVarRef

Methods:
	void Add(int inc)
	void Multiply(int multiplier)
	void Divide(int divider)
	void SetValue(int value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#intvar")]
	[AddComponentMenu("GameBooster/GlobalVar/Int/IntVar")]
	public class IntVar : GlobalVar<int> {

		protected override void LoadFromPlayerPrefsImplementation () {
			PlayerPrefs.SetInt (playerPrefsKey, m_value);
		}

		protected override void SaveOnPlayerPrefsImplementation () {
			m_value = PlayerPrefs.GetInt (playerPrefsKey);
		}

		public void Add(int inc){
			SetValue (value + inc);
		}
		public void Multiply(int multiplier){
			SetValue (value * multiplier);
		}
		public void Divide(int divider){
			SetValue (value / divider);
		}

	}
}