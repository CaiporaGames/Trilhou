using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster {
	
	[Comment(
@"Extra methods to control Rigidbody

Properties:
	float velocityX
	float velocityY
	float velocityZ
	float angularVelocityX
	float angularVelocityY
	float angularVelocityZ

Methods:
	//inverts rigidbody velocity (velocity = -velocity)
	void InvertVelocity()

	//inverts rigidbody x velocity (velocity.x = -velocity.x)
	void InvertVelocityX()

	//inverts rigidbody y velocity (velocity.y = -velocity.y)
	void InvertVelocityY()

	//inverts rigidbody z velocity (velocity.z = -velocity.z)
	void InvertVelocityZ()

	//inverts rigidbody angular velocity x (angularVelocity.x = -angularVelocity.x)
	void InvertAngularVelocityX()

	//inverts rigidbody angular velocity y (angularVelocity.y = -angularVelocity.y)
	void InvertAngularVelocityY()

	//inverts rigidbody angular velocity z (angularVelocity.z = -angularVelocity.z)
	void InvertAngularVelocityZ()

	//normalizes rigidbody velocity (velocity = velocity.normalized * speed
	void NormalizeVelocity(float speed)

	//normalizes rigidbody velocity xy
	void NormalizeVelocityXY(float speed)

	//normalizes rigidbody velocity xz
	void NormalizeVelocityXZ(float speed)

	//normalizes rigidbody velocity yz
	void NormalizeVelocityYZ(float speed)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#rigidbodymethods")]
	[AddComponentMenu("GameBooster/Physics/RidigbodyMethods")]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMethods : GameBoosterBehaviour {

		Rigidbody rb;

		public float velocityX { set { SetVelocity (0, value); } }
		public float velocityY { set { SetVelocity (1, value); } }
		public float velocityZ { set { SetVelocity (2, value); } }

		public float angularVelocityX { set { SetAngularVelocity (0, value); } }
		public float angularVelocityY { set { SetAngularVelocity (1, value); } }
		public float angularVelocityZ { set { SetAngularVelocity (2, value); } }

		void Awake(){
			rb = GetComponent<Rigidbody> ();
		}

		private void SetVelocity(int axisIndex, float value){
			var vel = rb.velocity;
			vel [axisIndex] = value;
			rb.velocity = vel;
		}
		private void SetAngularVelocity(int axisIndex, float value){
			var vel = rb.angularVelocity;
			vel [axisIndex] = value;
			rb.angularVelocity = vel;
		}
		private void NormalizeVelocityAxis(int axisIndex1, int axisIndex2, float speed){
			var vel = rb.velocity;
			var velN = new Vector2 (vel[axisIndex1], vel[axisIndex2]).normalized;
			vel[axisIndex1] = vel.x;
			vel[axisIndex2] = vel.y;
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
		public void InvertVelocityZ(){
			SetVelocity (2, -rb.velocity.z);
		}
		public void InvertAngularVelocityX(){
			SetAngularVelocity (0, rb.angularVelocity.x);
		}
		public void InvertAngularVelocityY(){
			SetAngularVelocity (1, rb.angularVelocity.y);
		}
		public void InvertAngularVelocityZ(){
			SetAngularVelocity (2, rb.angularVelocity.z);
		}
		public void NormalizeVelocity(float speed){
			rb.velocity = rb.velocity.normalized * speed;
		}
		public void NormalizeVelocityXY(float speed){
			NormalizeVelocityAxis (0, 1, speed);
		}
		public void NormalizeVelocityXZ(float speed){
			NormalizeVelocityAxis (0, 2, speed);
		}
		public void NormalizeVelocityYZ(float speed){
			NormalizeVelocityAxis (1, 2, speed);
		}





	}

}
