using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Gets key input events")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#keyinput")]
	[AddComponentMenu("GameBooster/Input/KeyInput")]
	public class KeyInput : GameBoosterBehaviour {

		public enum EventType { Pressed, Released, Repeat }
		[Tooltip("Type of key event")]
		public EventType eventType;

		[Tooltip("Key code")]
		public KeyCode key;

		public BoolUnityEvent actions;

		void Update(){
			if (eventType == EventType.Pressed && Input.GetKeyDown (key)) {
				actions.Invoke (true);
			}
			if (eventType == EventType.Released && Input.GetKeyUp (key)) {
				actions.Invoke (false);
			}
			if (eventType == EventType.Repeat) {
				actions.Invoke (Input.GetKey (key));
			}
		}

	}

}