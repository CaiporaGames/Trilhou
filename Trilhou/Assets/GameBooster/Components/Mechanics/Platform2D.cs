using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;

namespace GameBooster{

	[Comment(
@"Simple Platform character physics control.
		
Properties:
	//-1 to walk left, 1 to walk right, 0 to stop
	float walkInput

Methods:
	//jump if character is on ground
	void Jump()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#platform2d")]
	[AddComponentMenu("GameBooster/Mechanics/Platform2D")]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Platform2D : GameBoosterBehaviour {

		[Tooltip("Controls walk direction (-1:left, 0:stop, +1:right)")]
		[SerializeField]
		private float m_walkInput;
		public float walkInput {get{return m_walkInput;} set{m_walkInput=value;} }

		[Tooltip("Walk speed")]
		public float walkSpeed = 5;

		[Tooltip("Jump speed")]
		public float jumpSpeed = 12;

		[System.Serializable]
		public class GroundCheckConfig
		{
			[Tooltip("Physics Layers to check if character is toutching ground")]
			public LayerMask platformLayers = -1;
			[Tooltip("Raycast width")]
			public float width = 0.9f;
			[Tooltip("Raycast height")]
			public float height = 0.6f;
			[Tooltip("Number of raycasts")]
			[Range(2,5)]
			public int rays = 3;
		}
		public GroundCheckConfig groundCheckConfig;

		[System.Serializable]
		public class PlatformEvents {
			public UnityEvent onJump;
			public UnityEvent onLand;
			public UnityEvent onMoving;
			public UnityEvent onStop;
			public UnityEvent onAir;
		}

		public PlatformEvents events;


		[Tooltip("Use default input (keyboard arrows)")]
		public bool defaultInput = true;

		[Tooltip("Horizontal axis name")]
		[ConditionalHide("defaultInput")]
		public string horizontalAxis = "Horizontal";

		[Tooltip("Jump key")]
		[ConditionalHide("defaultInput")]
		public KeyCode jumpKey = KeyCode.UpArrow;

		Rigidbody2D rb;
		bool isGrounded;
		bool isMoving;

		void Awake(){
			rb = GetComponent<Rigidbody2D>();
		}

		void Update(){

			CheckGround();
			CheckMoving();

			if (defaultInput) {
				walkInput = Input.GetAxis (horizontalAxis);
				if (Input.GetKeyDown (jumpKey)) {
					Jump ();
				}
			}
		}


		RaycastHit2D[] hits = new RaycastHit2D[10];

		bool IsTouchinGround(){
			
			int groundCount = 0;

			for (int r = 0; r < groundCheckConfig.rays; r++) {
				float t = Mathf.InverseLerp (0, groundCheckConfig.rays - 1, r);
				var origin = rb.position + Vector2.right * Mathf.Lerp(-1,1,t) * groundCheckConfig.width/2;

				Debug.DrawRay (origin, Vector2.down * groundCheckConfig.height, Color.red);

				int n = Physics2D.RaycastNonAlloc (origin, Vector2.down, hits, groundCheckConfig.height, groundCheckConfig.platformLayers.value);

				for (int i = 0; i < n; i++) {
					if (hits [i].rigidbody == null) {
						groundCount++;
					} else if(hits [i].rigidbody != this.rb){
						groundCount++;
					}
				}
			}


			return groundCount > 0;
		}

		void OnDrawGizmosSelected(){
			if(groundCheckConfig != null){
				for (int r = 0; r < groundCheckConfig.rays; r++) {
					float t = Mathf.InverseLerp (0, groundCheckConfig.rays - 1, r);
					var origin = (Vector2)this.transform.position + Vector2.right * Mathf.Lerp (-1, 1, t) * groundCheckConfig.width / 2;

					Gizmos.color = Color.green;
					Gizmos.DrawRay (origin, Vector2.down * groundCheckConfig.height);

				}
			}
		}

		void CheckGround(){

			//bool currentIsGrounded = feetCollider && feetCollider.IsTouchingLayers(platformLayers.value);
			bool currentIsGrounded = IsTouchinGround();

			if (isGrounded != currentIsGrounded) {
				isGrounded = currentIsGrounded;
				if (isGrounded) {
					events.onLand.Invoke();
				} else {
					events.onAir.Invoke();
				}
			}
		}

		void CheckMoving(){

			bool currentIsMoving = Mathf.Abs(m_walkInput) > 0.01f;

			if (isMoving != currentIsMoving) {
				isMoving = currentIsMoving;
				if (isMoving) {
					events.onMoving.Invoke();
				} else {
					events.onStop.Invoke();
				}
			}

		}

		void FixedUpdate(){
			Vector2 vel = rb.velocity;
			vel.x = walkSpeed * m_walkInput;
			rb.velocity = vel;
		}

		void LateUpdate () {
			if( m_walkInput != 0 ){
				if( m_walkInput > 0 != this.transform.localScale.x > 0){
					Vector3 scale = this.transform.localScale;
					scale.x *= -1;
					this.transform.localScale = scale;
				}
			}
		}

		[Button]
		public void Jump(){
			if(isGrounded){
				Vector2 vel = rb.velocity;
				vel.y = jumpSpeed;
				rb.velocity = vel;
				events.onJump.Invoke();
			}
		}

	}

}