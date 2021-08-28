using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace GameBooster{

	[Comment(
@"MonoBehaviour event triggers.

Events:
	void Awake()
	void OnEnable()
	void Start()
	void FixedUpdate()
	void Update()
	void LateUpdate()
	void OnBecameVisible()
	void OnBecameInvisible()
	void OnApplicationPause()
	void OnApplicationResume()
	void OnApplicationQuit()
	void OnDisable()
	void OnDestroy()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#behaviourevents")]
	[AddComponentMenu("GameBooster/Basics/BehaviourEvents")]
	public class BehaviourEvents : GameBoosterBehaviour {

		public enum EventType {
			Awake,
			OnEnable,
			Start,
			FixedUpdate,
			Update,
			LateUpdate,
			OnBecameVisible,
			OnBecameInvisible,
			OnApplicationPause,
			OnApplicationResume,
			OnApplicationQuit,
			OnDisable,
			OnDestroy,
		}

		[Tooltip("Behaviour event")]
		public EventType eventType;

		public UnityEvent actions;

		void CheckTypeAndCall(EventType type){
			if (this.eventType == type)
				actions.Invoke ();
		}

		void Awake () {
			CheckTypeAndCall (EventType.Awake);
		}
		void Start () {
			CheckTypeAndCall (EventType.Start);
		}
		void Update () {
			CheckTypeAndCall (EventType.Update);
		}
		void FixedUpdate () {
			CheckTypeAndCall (EventType.FixedUpdate);
		}
		void LateUpdate () {
			CheckTypeAndCall (EventType.LateUpdate);
		}
		void OnApplicationPause (bool pauseStatus) {
			CheckTypeAndCall (pauseStatus ? EventType.OnApplicationPause : EventType.OnApplicationResume);
		}
		void OnApplicationQuit () {
			CheckTypeAndCall (EventType.OnApplicationQuit);
		}
		void OnBecameInvisible () {
			CheckTypeAndCall (EventType.OnBecameInvisible);
		}
		void OnBecameVisible () {
			CheckTypeAndCall (EventType.OnBecameVisible);
		}
		void OnDestroy () {
			CheckTypeAndCall (EventType.OnDestroy);
		}
		void OnDisable () {
			CheckTypeAndCall (EventType.OnDisable);
		}
		void OnEnable () {
			CheckTypeAndCall (EventType.OnEnable);
		}
	}

}