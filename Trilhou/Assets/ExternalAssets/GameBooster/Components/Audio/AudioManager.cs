using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster {

	[Comment(
@"Manager for many AudioSources

Methods:
	//Play the AudioSource with the object name passed as parameter
	void PlayAudio(string name)

	//Stop the AudioSource with the object name passed as parameter
	void StopAUdio(string name)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#audiomanager")]
	[AddComponentMenu("GameBooster/Audio/AudioManager")]
	public class AudioManager : GameBoosterBehaviour {

		[Tooltip("Managed audiosources")]
        [Reorderable]
		public List<AudioSource> audios;

		public void PlayAudio(string name){
			for (int i = 0; i < audios.Count; i++) {
				if (audios [i].name == name) {
					PlayAudio (i);
				}
			}
		}
		void PlayAudio(int index){
			audios [index].Play ();
		}

		public void StopAudio(string name){
			for (int i = 0; i < audios.Count; i++) {
				if (audios [i].name == name) {
					StopAudio (i);
				}
			}
		}
		void StopAudio(int index){
			audios [index].Stop ();
		}

	}
}