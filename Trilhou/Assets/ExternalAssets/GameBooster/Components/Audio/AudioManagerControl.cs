using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster {

	[Comment(
@"Commands the AudioManager

Methods:
	//Play the AudioSource with the object name passed as parameter
	void PlayAudio(string name)

	//Stop the AudioSource with the object name passed as parameter
	void StopAUdio(string name)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#audiomanagercontrol")]
	[AddComponentMenu("GameBooster/Audio/AudioManagerControl")]
	public class AudioManagerControl : GameBoosterBehaviour {

		AudioManager manager;

		void Start () {
			manager = GameObject.FindObjectOfType<AudioManager> ();
		}

		public void PlayAudio(string name){
			if(manager)
				manager.PlayAudio (name);
		}
		public void StopAudio(string name){
			if(manager)
				manager.StopAudio (name);
		}

	}

}