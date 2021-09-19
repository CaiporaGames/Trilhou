using UnityEngine;
using System.Collections;

namespace GameBooster {

	[Comment(@"Follow a target position")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#followtarget3d")]
	[AddComponentMenu("GameBooster/Movement/FollowTarget3D")]
	public class FollowTarget3D : GameBoosterBehaviour {

		[Tooltip("Target that will be followed")]
		public Transform target;

		[Tooltip("Position offset from target")]
		public Vector3 offset;

		[Tooltip("Speed at which the object will move to target\n0(zero) = infinity speed")]
		public float speed;

		public enum Axis { XYZ, XY, XZ, YZ, X, Y, Z }
		[Tooltip("Axis affected by target position")]
		public Axis axis = Axis.XYZ;

        [Tooltip("Execute on LateUpdate() instead of Update() or FixedUpdate()")]
        public bool lateUpdate;

        Rigidbody rb;

		void Awake () {
			rb = GetComponent<Rigidbody> ();
		}

		float Speed(){
			return Mathf.Approximately (speed, 0) ? float.PositiveInfinity : speed;
		}

        void LateUpdate()
        {
            if(target && lateUpdate)
            {
                if (rb)
                    FixedUpdateLogic();
                else
                    UpdateLogic();
            }
        }

        void Update () {
			if (target && !rb && !lateUpdate) {
                UpdateLogic();
			}
		}
        
		void FixedUpdate(){
			if (target && rb && !lateUpdate) {
                FixedUpdateLogic();
			}
		}

        void UpdateLogic()
        {
            Vector3 targetPos = target.position + offset;
            Vector3 direction = targetPos - this.transform.position;
            if (direction.magnitude > 0)
            {
                Vector3 newPosition = Vector3.MoveTowards(this.transform.position, targetPos, Speed() * Time.deltaTime);
                Vector3 position = this.transform.position;

                if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.XZ || axis == Axis.X)
                    position.x = newPosition.x;

                if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.YZ || axis == Axis.Y)
                    position.y = newPosition.y;

                if (axis == Axis.XYZ || axis == Axis.XZ || axis == Axis.YZ || axis == Axis.Z)
                    position.z = newPosition.z;

                this.transform.position = position;
            }
        }
        void FixedUpdateLogic()
        {
            Vector3 targetPos = target.position + offset;
            Vector3 direction = targetPos - rb.position;
            if (direction.magnitude > 0)
            {
                Vector3 newPosition = Vector3.MoveTowards(rb.position, targetPos, Speed() * Time.deltaTime);
                Vector3 position = rb.position;

                if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.XZ || axis == Axis.X)
                    position.x = newPosition.x;

                if (axis == Axis.XYZ || axis == Axis.XY || axis == Axis.YZ || axis == Axis.Y)
                    position.y = newPosition.y;

                if (axis == Axis.XYZ || axis == Axis.XZ || axis == Axis.YZ || axis == Axis.Z)
                    position.z = newPosition.z;

                rb.MovePosition(position);
            }
        }

	}

}