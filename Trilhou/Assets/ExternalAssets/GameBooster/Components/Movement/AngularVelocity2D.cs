using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"Controls the Rigidbody2D/Transform angular velocity

Properties:
	float velocity

Methods:
	//applies the velocity
	void ApplyVelocity()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#angularvelocity2d")]
	[AddComponentMenu("GameBooster/Movement/AngularVelocity2D")]
	public class AngularVelocity2D : GameBoosterBehaviour {

		[Tooltip("Current velocity")]
		[SerializeField]
		private float m_velocity = 360f;
		public float velocity { get { return m_velocity; } set { m_velocity = value; } }

		public enum ControlType { Continuous, OnStart, OnEnable, Manual }
		[Tooltip("How the angular velocity is controled")]
		public ControlType controlType;

		Rigidbody2D rb;

		void Awake () {
			rb = GetComponent<Rigidbody2D> ();
		}

		void Start(){
			if (controlType == ControlType.OnStart) {
				ApplyVelocity ();
			}
		}

		void OnEnable(){
			if (controlType == ControlType.OnEnable) {
				ApplyVelocity ();
			}
		}

		void FixedUpdate () {
			if (controlType == ControlType.Continuous) {
				ApplyVelocity ();
			}
		}

		public void ApplyVelocity(){
			if (rb) {
				ApplyVelocityRigidbody ();
			} else {
				ApplyVelocityTransform ();
			}
		}

		private void ApplyVelocityTransform(){
			transform.Rotate (0, 0, m_velocity * Time.deltaTime);
		}
		private void ApplyVelocityRigidbody(){
			rb.angularVelocity = m_velocity;
		}
	}

}