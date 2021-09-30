using UnityEngine;
using System.Collections;

namespace GameBooster {

	[Comment(@"Follow a target position")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#followtarget2d")]
	[AddComponentMenu("GameBooster/Movement/FollowTarget2D")]
	public class FollowTarget2D : GameBoosterBehaviour {

		[Tooltip("Target that will be followed")]
		public Transform target;

		[Tooltip("Position offset from target")]
		public Vector2 offset;

		[Tooltip("Speed at which the object will move to target\n0(zero) = infinity speed")]
		public float speed;

		public enum Axis { XY, X, Y }
		[Tooltip("Axis affected by target position")]
		public Axis axis = Axis.XY;

        [Tooltip("Execute on LateUpdate() instead of Update() or FixedUpdate()")]
        public bool lateUpdate;

		Rigidbody2D rb;

		void Awake () {
			rb = GetComponent<Rigidbody2D> ();
		}

		float Speed(){
			return Mathf.Approximately (speed, 0) ? float.PositiveInfinity : speed;
		}

        private void LateUpdate()
        {
            if (lateUpdate && target)
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
            Vector2 targetPos = (Vector2)target.position + offset;
            Vector2 direction = targetPos - (Vector2)this.transform.position;
            if (direction.magnitude > 0)
            {
                Vector2 newPosition = Vector2.MoveTowards(this.transform.position, targetPos, Speed() * Time.deltaTime);
                Vector3 position = this.transform.position;

                if (axis == Axis.XY || axis == Axis.X)
                    position.x = newPosition.x;

                if (axis == Axis.XY || axis == Axis.Y)
                    position.y = newPosition.y;

                this.transform.position = position;
            }
        }
        void FixedUpdateLogic()
        {
            Vector2 targetPos = (Vector2)target.position + offset;
            Vector3 direction = targetPos - rb.position;
            if (direction.magnitude > 0)
            {
                Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPos, Speed() * Time.deltaTime);
                Vector2 position = rb.position;

                if (axis == Axis.XY || axis == Axis.X)
                    position.x = newPosition.x;

                if (axis == Axis.XY || axis == Axis.Y)
                    position.y = newPosition.y;

                rb.MovePosition(position);
            }
        }

	}

}