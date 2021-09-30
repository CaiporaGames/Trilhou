using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Limits the rididbody speed below a value")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#speedlimit3d")]
	[AddComponentMenu("GameBooster/Physics/SpeedLimit3D")]
	[RequireComponent(typeof(Rigidbody))]
	public class SpeedLimit3D : GameBoosterBehaviour {

		[Tooltip("Maximum speed allowed")]
		public float maxSpeed = 10;

		Rigidbody rb;

		void Awake(){
			rb = GetComponent<Rigidbody> ();
		}

		void FixedUpdate () {
			if (rb.velocity != Vector3.zero) {
				var currentVelocity = rb.velocity.magnitude;
				if (currentVelocity > maxSpeed) {
					rb.velocity = rb.velocity.normalized * maxSpeed;
				}
			}
		}
	}

}