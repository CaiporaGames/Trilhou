using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GameBooster{

	[Comment(@"Executes a sequence of actions with time between them.")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#timedactionsequence")]
	[AddComponentMenu("GameBooster/Time/TimedActionSequence")]
	public class TimedActionSequence : GameBoosterBehaviour {

		[System.Serializable]
		public class TimedAction{
			[Tooltip("Time to wait before execute")]
			public float waitTime;
			[Tooltip("Actions to execute")]
			public UnityEvent actions;
		}

		[Tooltip("Actions to be executed")]
        [Reorderable]
		public TimedAction[] actions;

		public enum ControlType { OnStart, OnEnable, Manual }
		
		[Tooltip("How actions are executed")]
		public ControlType controlType = ControlType.OnStart;

		[Tooltip("Continuous execute actions")]
		public bool continuous;
		
		void Start(){
			if(controlType == ControlType.OnStart){
				CallActions();
			}
		}
		
		void OnEnable(){
			if(controlType == ControlType.OnEnable){
				CallActions();
			}
		}

		[Button]
		public void CallActions(){
			StartCoroutine (CallActionsCR ());
		}

		IEnumerator CallActionsCR(){
			for (int i = 0; i < actions.Length; i++) {
				yield return new WaitForSeconds (actions [i].waitTime);
				actions [i].actions.Invoke ();
			}
			if(continuous){
				CallActions();
			}
		}

	}

}