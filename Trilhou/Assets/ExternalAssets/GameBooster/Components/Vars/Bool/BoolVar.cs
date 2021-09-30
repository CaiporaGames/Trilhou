using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
		@"Stores a global bool variable

Related components:
	BoolVarRef

Methods:
	void Or(bool value)
	void And(bool value)
	void Neg()
	void SetValue(bool value)
	void ResetValue()
	void SaveOnPlayerPrefs()
	void LoadFromPlayerPrefs()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#boolvar")]
	[AddComponentMenu("GameBooster/GlobalVar/Bool/BoolVar")]
	public class BoolVar : GlobalVar<bool> {
		
		protected override void LoadFromPlayerPrefsImplementation () {
			PlayerPrefs.SetInt (playerPrefsKey, m_value ? 1 : 0);
		}
		protected override void SaveOnPlayerPrefsImplementation () {
			m_value = PlayerPrefs.GetInt (playerPrefsKey) != 0;
		}

		public void Or(bool value){
			SetValue (this.value || value);
		}
		public void And(bool value){
			SetValue (this.value && value);
		}
		public void Neg(){
			SetValue (!value);
		}

	}
}