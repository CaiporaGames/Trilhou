using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster {

	[Comment(
@"Extra methods to control Rigidbody2D

Properties:
	float velocityX
	float velocityY

Methods:
	//inverts rigidbody velocity (velocity = -velocity)
	void InvertVelocity()

	//inverts rigidbody x velocity (velocity.x = -velocity.x)
	void InvertVelocityX()

	//inverts rigidbody y velocity (velocity.y = -velocity.y)
	void InvertVelocityY()

	//inverts rigidbody angular velocity (angularVelocity = -angularVelocity)
	void InvertAngularVelocity()

	//normalizes rigidbody velocity (velocity = velocity.normalized * speed
	void NormalizeVelocity(float speed)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#rigidbody2dmethods")]
	[AddComponentMenu("GameBooster/Physics/Ridigbody2DMethods")]
	[RequireComponent(typeof(Rigidbody2D))]
	public class Rigidbody2DMethods : GameBoosterBehaviour {

		Rigidbody2D rb;

		public float velocityX { set { SetVelocity (0, value); } }
		public float velocityY { set { SetVelocity (1, value); } }

		void Awake(){
			rb = GetComponent<Rigidbody2D> ();
		}

		private void SetVelocity(int axisIndex, float value){
			var vel = rb.velocity;
			vel [axisIndex] = value;
			rb.velocity = vel;
		}

		public void InvertVelocity(){
			rb.velocity = -rb.velocity;
		}
		public void InvertVelocityX(){
			SetVelocity (0, -rb.velocity.x);
		}
		public void InvertVelocityY(){
			SetVelocity (1, -rb.velocity.y);
		}
		public void InvertAngularVelocity(){
			rb.angularVelocity = -rb.angularVelocity;
		}
		public void NormalizeVelocity(float speed){
			rb.velocity = rb.velocity.normalized * speed;
		}

	}

}
