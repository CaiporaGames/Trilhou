using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(
@"Simple Tank (walk forward and rotate) physics control.

Properties:
	//1 to turn right, -1 to turn left, 0 to stop
	float turnInput
	
	//1 to move forward, -1 to turn backwards, 0 to stop
	float moveInput"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#tank2d")]
	[AddComponentMenu("GameBooster/Mechanics/Tank2D")]
	[RequireComponent(typeof(Velocity2D))]
	[RequireComponent(typeof(AngularVelocity2D))]
	public class Tank2D : GameBoosterBehaviour {

		[Tooltip("Controls Tank turn direction (-1:left, 0:stop, +1:right)")]
		[SerializeField]
		private float m_turnInput;
		public float turnInput {get{return m_turnInput;} set{m_turnInput=value;} }

		[Tooltip("Controls Tank move direction (-1:backward, 0:stop, +1:forward)")]
		[SerializeField]
		private float m_moveInput;
		public float moveInput {get{return m_moveInput;} set{m_moveInput=value;} }

		[Tooltip("Move speed")]
		public float moveSpeed = 5;
		[Tooltip("Turn speed (degrees/second)")]
		public float turnSpeed = 90;

		[Tooltip("If the Tank can only turn if its moving")]
		public bool onlyTurnIfMoving;


		[Tooltip("If use default input (keyboard arrows)")]
		public bool defaultInput = true;

		[Tooltip("Horizontal (turn) axis name")]
		[ConditionalHide("defaultInput")]
		public string horizontalAxis = "Horizontal";

		[Tooltip("Vertical (move) axis name")]
		[ConditionalHide("defaultInput")]
		public string verticalAxis = "Vertical";

		Velocity2D vel;
		AngularVelocity2D avel;
		
		void OnValidate(){
			GetComponent<Velocity2D> ().local = true;
			GetComponent<Velocity2D> ().controlType = Velocity2D.ControlType.Continuous;
			GetComponent<Velocity2D> ().velocity = Vector2.zero;
			GetComponent<AngularVelocity2D> ().controlType = AngularVelocity2D.ControlType.Continuous;
			GetComponent<AngularVelocity2D> ().velocity = 0;
			GetComponent<Rigidbody2D> ().gravityScale = 0;
		}

		void Start () {
			vel = GetComponent<Velocity2D> ();
			avel = GetComponent<AngularVelocity2D> ();
		}
		
		void Update () {
			if (defaultInput) {
				turnInput = Input.GetAxis (horizontalAxis);
				moveInput = Input.GetAxis (verticalAxis);
			}
			vel.velocityY = moveInput * moveSpeed;
			avel.velocity = -turnInput * turnSpeed * Mathf.Sign(moveInput) * (onlyTurnIfMoving ? Mathf.Abs(moveInput) : 0f);
		}
	}
}