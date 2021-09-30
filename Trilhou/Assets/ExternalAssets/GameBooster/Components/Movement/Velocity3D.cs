using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
		@"Controls Rigidbody3D/Transform velocity

Properties:
	Vector3 velocity
	float velocityX
	float velocityY
	float velocityZ

Methods:
	//applies the velocity
	void ApplyVelocity()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#velocity3d")]
	[AddComponentMenu("GameBooster/Movement/Velocity3D")]
	public class Velocity3D : GameBoosterBehaviour {

		[Tooltip("Current velocity")]
		[SerializeField]
		private Vector3 m_velocity = Vector3.forward;
		public Vector3 velocity { get{ return m_velocity; } set { m_velocity = value; } }
		public float velocityX { set { m_velocity.x = value; } }
		public float velocityY { set { m_velocity.y = value; } }
		public float velocityZ { set { m_velocity.z = value; } }

		[Tooltip("Use object local orientation")]
		public bool local;

		public enum ControlType { Continuous, OnStart, OnEnable, Manual }
		[Tooltip("How the velocity is controlled")]
		public ControlType controlType;

		public enum Axis { XYZ, XY, XZ, YZ, X, Y, Z }
		[Tooltip("Axis affected")]
		public Axis axis;

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

		void ChangeVelocity(ref Vector3 velocity){
			if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.XZ || axis == Axis.X)
				velocity.x = m_velocity.x;
			if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.YZ || axis == Axis.Y)
				velocity.y = m_velocity.y;
			if (axis == Axis.XYZ || axis == Axis.XZ || axis == Axis.YZ || axis == Axis.Z)
				velocity.z = m_velocity.z;
		}

		public void ApplyVelocity(){
			if (rb) {
				ApplyVelocityRigidbody ();
			} else {
				ApplyVelocityTransform ();
			}
		}

		private void ApplyVelocityTransform(){
			var velocity = Vector3.zero;
			ChangeVelocity (ref velocity);
			transform.Translate (velocity * Time.deltaTime, local ? Space.Self : Space.World);
		}

		private void ApplyVelocityRigidbody(){
			if (local) {
				var velocity = Quaternion.Inverse(rb.rotation) * rb.velocity;
				ChangeVelocity (ref velocity);
				rb.velocity = rb.rotation * velocity;
			} else {
				var velocity = rb.velocity;
				ChangeVelocity (ref velocity);
				rb.velocity = velocity;
			}
		}
	}

}