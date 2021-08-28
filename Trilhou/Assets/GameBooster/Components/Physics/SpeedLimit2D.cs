using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Limits the rididbody speed below a value")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#speedlimit2d")]
	[AddComponentMenu("GameBooster/Physics/SpeedLimit2D")]
	[RequireComponent(typeof(Rigidbody2D))]
	public class SpeedLimit2D : GameBoosterBehaviour {

		[Tooltip("Maximum speed allowed")]
		public float maxSpeed = 10;

		Rigidbody2D rb;

		void Awake(){
			rb = GetComponent<Rigidbody2D> ();
		}

		void FixedUpdate () {
			if (rb.velocity != Vector2.zero) {
				var currentVelocity = rb.velocity.magnitude;
				if (currentVelocity > maxSpeed) {
					rb.velocity = rb.velocity.normalized * maxSpeed;
				}
			}
		}
	}

}