using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Gets axis input value")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#axisinput")]
	[AddComponentMenu("GameBooster/Input/AxisInput")]
	public class AxisInput : GameBoosterBehaviour {

		[Tooltip("Axis name")]
		public string axisName = "Horizontal";

		[Tooltip("Get input raw value")]
		public bool raw;

		[Tooltip("Axis value multiplier")]
		public float multiplier = 1;

		public FloatUnityEvent actions;

		private float m_value;
		[InspectorDebugger]
		public float value { get { return m_value; } }

		void Update () {
			float value = (raw ? Input.GetAxisRaw (axisName) : Input.GetAxis (axisName)) * multiplier;
			m_value = value;
			actions.Invoke (value);
		}
        
	}

}