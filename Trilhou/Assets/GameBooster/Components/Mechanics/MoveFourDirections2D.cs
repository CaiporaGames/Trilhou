using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Controls an object in all directions")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#movefourdirections2d")]
	[AddComponentMenu("GameBooster/Mechanics/MoveFourDirections2D")]
	[RequireComponent(typeof(Velocity2D))]
	public class MoveFourDirections2D : GameBoosterBehaviour {

		[Tooltip("Horizontal axis name")]
		public string horizontalAxis = "Horizontal";
		[Tooltip("Vertical axis name")]
		public string verticalAxis = "Vertical";

		[Tooltip("Normalized speed")]
		[SerializeField]
		private float m_speed = 5;
		public float speed { get{ return m_speed; } set{ m_speed = value; } }

		Velocity2D vel;

		void Start () {
			vel = GetComponent<Velocity2D> ();
		}

		void Update () {
			float h = Input.GetAxis (horizontalAxis);
			float v = Input.GetAxis (verticalAxis);
			var dir = new Vector2 (h, v);
			if (dir.sqrMagnitude > 1f) {
				dir.Normalize ();
			}
			vel.velocity = dir * m_speed;
		}
	}

}