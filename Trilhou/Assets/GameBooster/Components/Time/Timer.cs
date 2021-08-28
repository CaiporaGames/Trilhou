using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"A timer (clock).

Methods:
	void Pause()
	void Resume()
	void SwitchPause()
	void AddTime(float time)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#timer")]
	[AddComponentMenu("GameBooster/Time/Timer")]
	public class Timer : GameBoosterBehaviour {

		[Tooltip("Current time (seconds)")]
		public float currentTime;

		[Tooltip("Initial time")]
		public float startTime;

		[Tooltip("If the timer is countdown")]
		public bool countdown;

		[Tooltip("Minimum timer value")]
		public float minValue = 0;
		[Tooltip("Maximum timer value")]
		public float maxValue = 60;

		[Tooltip("If the timer is paused")]
		public bool paused;

		[System.Serializable]
		public class TimerEvents{
			[Tooltip("Event called when the timer value changes")]
			public FloatUnityEvent onChange;
			[Tooltip("Event called when the timer reaches the min value")]
			public FloatUnityEvent onMinValue;
			[Tooltip("Event called when the timer reaches the max value")]
			public FloatUnityEvent onMaxValue;

			[Tooltip("Digits to show at the OnChangeText event")]
			[Range(0,5)]
			public int textDigits;
			[Tooltip("Event called when the timer value changes, passing a string as parameter")]
			public StringUnityEvent onChangeText;

			public static readonly string[] digitsFormats = {"0","0.0","0.00","0.000","0.0000","0.00000"};
		}
		[Tooltip("Timer events")]
		public TimerEvents events;

		void Start () {
			currentTime = startTime;
		}

		void Update () {
			if (!paused) {
				var delta = Time.deltaTime;
				if (countdown)
					delta = -delta;

				bool wasMinValue = Mathf.Approximately (currentTime, minValue);
				bool wasMaxValue = Mathf.Approximately (currentTime, maxValue);

				currentTime = Mathf.Clamp (currentTime + delta, minValue, maxValue);

				events.onChange.Invoke (currentTime);

				if (!wasMinValue && Mathf.Approximately (currentTime, minValue))
					events.onMinValue.Invoke (currentTime);

				if (!wasMaxValue && Mathf.Approximately (currentTime, maxValue))
					events.onMaxValue.Invoke (currentTime);

				if (events.onChangeText.GetPersistentEventCount () > 0) {
					events.onChangeText.Invoke(string.Format (TimerEvents.digitsFormats [events.textDigits], currentTime));
				}
			}
		}

		public void AddTime(float time){
			currentTime = Mathf.Clamp (currentTime + time, minValue, maxValue);
		}

		[Button]
		public void Pause(){
			paused = true;
		}
		[Button]
		public void Resume(){
			paused = false;
		}
		[Button]
		public void SwitchPause(){
			paused = !paused;
		}
	}

}