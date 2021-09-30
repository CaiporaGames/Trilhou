using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(
@"Follows a position relative to screen.

Methods:
	//applies the position
	void ApplyPosition()"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#followscreenposition2d")]
	[AddComponentMenu("GameBooster/Movement/FollowScreenPosition2D")]
	public class FollowScreenPosition2D : GameBoosterBehaviour {

		public enum ControlType { Continuous, OnStart, OnEnable, Manual }
		[Tooltip("How the position is controled")]
		public ControlType controlType = ControlType.Continuous;

		[Tooltip("Screen viewport anchor (from 0.0 to 1.0)")]
		public Vector2 viewportAnchor = new Vector2(.5f,.5f);

		[Tooltip("Position offset in world coordinates")]
		public Vector2 offset;

		Rigidbody2D rb;

		void Start(){
			rb = GetComponent<Rigidbody2D>();

			if (controlType == ControlType.OnStart)
				ApplyPosition ();
		}
		void OnEnable(){
			rb = GetComponent<Rigidbody2D>();
			
			if (controlType == ControlType.OnEnable)
				ApplyPosition ();
		}
		void Update(){
			if (controlType == ControlType.Continuous && !rb) {
				ApplyPosition ();
			}
		}
		void FixedUpdate(){
			if (controlType == ControlType.Continuous && rb) {
				ApplyPosition ();
			}
		}

		[Button]
		public void ApplyPosition(){
			Vector3 pos = Camera.main.ViewportToWorldPoint(viewportAnchor);
			pos.z = 0;
			pos += (Vector3)offset;

			if (rb) {
				rb.MovePosition (pos);
			} else {
				this.transform.position = pos;
			}
		}

		void OnDrawGizmosSelected(){
			Vector2 camPos = Camera.main.ViewportToWorldPoint(viewportAnchor);
			Vector2 offsetPos = camPos + offset;

			Vector2 bottonLeft = Camera.main.ViewportToWorldPoint (Vector2.zero);
			Vector2 topRight = Camera.main.ViewportToWorldPoint (Vector2.one);

			var p1 = new Vector2 (camPos.x, topRight.y);
			var p2 = new Vector2 (camPos.x, bottonLeft.y);

			var p3 = new Vector2 (bottonLeft.x, camPos.y);
			var p4 = new Vector2 (topRight.x, camPos.y);

			Gizmos.color = Color.red;
			Gizmos.DrawLine (p1, p2);
			Gizmos.DrawLine (p3, p4);

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine (camPos, offsetPos);

#if UNITY_EDITOR
            Gizmos.DrawWireCube (offsetPos, new Vector3 (0.1f, 0.1f, 0) * UnityEditor.HandleUtility.GetHandleSize(offsetPos));
#endif
        }

	}

}