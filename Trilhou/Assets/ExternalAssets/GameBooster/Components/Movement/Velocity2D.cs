using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[Comment(
@"Controls Rigidbody2D/Transform velocity

Properties:
	Vector2 velocity
	float velocityX
	float velocityY

Methods:
	//applies the velocity
	void ApplyVelocity()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#velocity2d")]
	[AddComponentMenu("GameBooster/Movement/Velocity2D")]
	public class Velocity2D : GameBoosterBehaviour {

		[Tooltip("Current velocity")]
		[SerializeField]
		private Vector2 m_velocity = Vector2.up;
		public Vector2 velocity { get { return m_velocity; } set { m_velocity = value; } }

		public float velocityX { set { m_velocity.x = value; } }
		public float velocityY { set { m_velocity.y = value; } }

		[Tooltip("Use object local orientation")]
		public bool local;

		public enum ControlType { Continuous, OnStart, OnEnable, Manual }
		[Tooltip("How the velocity is controlled")]
		public ControlType controlType;

		public enum Axis { XY, X, Y }
		[Tooltip("Axis affected")]
		public Axis axis;

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

		void ChangeVelocity(ref Vector2 velocity){
			if (axis == Axis.XY || axis == Axis.X)
				velocity.x = m_velocity.x;
			if (axis == Axis.XY || axis == Axis.Y)
				velocity.y = m_velocity.y;
		}

		public void ApplyVelocity(){
			if (rb) {
				ApplyVelocityRigidbody ();
			} else {
				ApplyVelocityTransform ();
			}
		}

		private void ApplyVelocityTransform(){
			var velocity = Vector2.zero;
			ChangeVelocity (ref velocity);
			transform.Translate (velocity * Time.deltaTime, local ? Space.Self : Space.World);
		}

		private void ApplyVelocityRigidbody(){
			if (local) {
				var velocity = (Vector2)(Quaternion.Euler (0, 0, -rb.rotation) * rb.velocity);
				ChangeVelocity (ref velocity);
				rb.velocity = (Vector2)(Quaternion.Euler (0, 0, rb.rotation) * velocity);
			} else {
				var velocity = rb.velocity;
				ChangeVelocity (ref velocity);
				rb.velocity = velocity;
			}
		}

	}

}