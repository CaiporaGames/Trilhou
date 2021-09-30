using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GameBooster{

	[Comment(@"Executes actions repeatedly over time")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#timedactions")]
	[AddComponentMenu("GameBooster/Time/TimedActions")]
	public class TimedActions : GameBoosterBehaviour {

		[Tooltip("Time to wait before the first execution starts")]
		public float startTime;
		[Tooltip("Time between two executions")]
		public float repeatTime;

		public UnityEvent actions;

		void OnEnable () {
			if (startTime == 0) {
				CallTimed ();
			} else {
				Invoke ("CallTimed", startTime);
			}
		}

		void OnDisable(){
			CancelInvoke("CallTimed");
		}

		void CallTimed () {
			CallActions();
			if(repeatTime > 0)
				Invoke ("CallTimed", repeatTime);
		}

		void CallActions(){
			actions.Invoke();
		}
	}

}