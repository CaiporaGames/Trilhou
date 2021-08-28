using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"Controls the Rigidbody3D/Transform angular velocity

Properties:
	Vector3 angularVelocity
	float angularVelocityX
	float angularVelocityY
	float angularVelocityZ

Methods:
	//applies the velocity
	void ApplyVelocity()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#angularvelocity3d")]
	[AddComponentMenu("GameBooster/Movement/AngularVelocity3D")]
	public class AngularVelocity3D : GameBoosterBehaviour {

		[Tooltip("Current velocity")]
		[SerializeField]
		private Vector3 m_angularVelocity = Vector3.up * 360f;

		public Vector3 angularVelocity { get { return m_angularVelocity; } set { m_angularVelocity = value; } }
		public float angularVelocityX { set { m_angularVelocity.x = value; } }
		public float angularVelocityY { set { m_angularVelocity.y = value; } }
		public float angularVelocityZ { set { m_angularVelocity.z = value; } }

		public enum ControlType { Continuous, OnStart, OnEnable, Manual }
		[Tooltip("How the angular velocity is controled")]
		public ControlType controlType;

		Rigidbody rb;

		void Awake () {
			rb = GetComponent<Rigidbody> ();
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
			transform.Rotate (m_angularVelocity * Time.deltaTime);
		}
		private void ApplyVelocityRigidbody(){
			rb.angularVelocity = m_angularVelocity * Mathf.Deg2Rad;
		}
	}

}