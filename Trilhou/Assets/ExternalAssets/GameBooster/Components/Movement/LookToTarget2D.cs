using UnityEngine;
using System.Collections;

namespace GameBooster {

	[Comment(@"Makes the object look (rotate) to some target")]
	[AddComponentMenu("GameBooster/Movement/LookToTarget2D")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#looktotarget2d")]
	public class LookToTarget2D : GameBoosterBehaviour {

		[Tooltip("Target the object will look")]
		public Transform target;
		
		[Tooltip("Speed at which the object will rotate\n0(zero) = infinity speed")]
		public float speed;

		[Tooltip("Offset to fix object rotation")]
		public float angleOffset;

		Rigidbody2D rb;

		void Awake () {
			rb = GetComponent<Rigidbody2D> ();
		}

		float CalcAngle(){
			Vector2 dir = (Vector2)(target.position - this.transform.position);
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			return angle + angleOffset;
		}

		float Speed(){
			return speed == 0 ? float.PositiveInfinity : speed;
		}

		void Update () {
			if (target && !rb) {
				float newAngle = Mathf.MoveTowardsAngle (this.transform.rotation.eulerAngles.z, CalcAngle (), Speed() * Time.deltaTime);
				this.transform.rotation = Quaternion.Euler (0, 0, newAngle);
			}
		}

		void FixedUpdate(){
			if (target && rb) {
				float newAngle = Mathf.MoveTowardsAngle (rb.rotation, CalcAngle (), Speed() * Time.fixedDeltaTime);
				rb.MoveRotation (newAngle);
			}
		}

	}

}