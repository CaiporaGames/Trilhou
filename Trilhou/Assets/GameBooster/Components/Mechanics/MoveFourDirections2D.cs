using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Controls an object in all directions")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#movefourdirections2d")]
	[AddComponentMenu("GameBooster/Mechanics/MoveFourDirections2D")]
	[RequireComponent(typeof(Velocity2D))]
	public class MoveFourDirections2D : GameBoosterBehaviour {
		[Header("Axis")]
		[Tooltip("Horizontal axis name")]
		public string horizontalAxis = "Horizontal";
		[Tooltip("Vertical axis name")]
		public string verticalAxis = "Vertical";

		[Header("Direction Limitations")]
		[Tooltip("This is to limite the x and y movements of the player to not be beyond the bounderies")]

		[Range(0.0f, -100.0f)]
		[SerializeField] float xMinDirection = -5;
		[Range(0f, 100f)]
		[SerializeField] float xMaxDirection = 5;
		[Range(0f, -100f)]
		[SerializeField] float yMinDirection = -5;
		[Range(0f, 100f)]
		[SerializeField] float yMaxDirection = 5;

		[Header("Stats")]
		[Tooltip("Normalized speed")]
		[Range(0f, 100f)]
		[SerializeField] float m_speed = 5;
		public float speed { get{ return m_speed; } set{ m_speed = value; } }

		Velocity2D vel;

		void Start () {
			vel = GetComponent<Velocity2D> ();
		}

		void Update () {

			float h = Input.GetAxis (horizontalAxis);
			float v = Input.GetAxis (verticalAxis);
			var dir = new Vector2 (h, v);
			dir.Normalize();

			vel.velocity = dir * m_speed;

			Limitator();

		}

		void Limitator()///apply the limitations to the movement
        {
			if (transform.position.x > xMaxDirection)
			{
				transform.position = new Vector3(xMaxDirection, transform.position.y, transform.position.z);
			}
			if (transform.position.x < xMinDirection)
			{
				transform.position = new Vector3(xMinDirection, transform.position.y, transform.position.z);
			}

			if (transform.position.y > yMaxDirection)
			{
				transform.position = new Vector3(transform.position.x, yMaxDirection, transform.position.z);
			}
			if (transform.position.y < yMinDirection)
			{
				transform.position = new Vector3(transform.position.x, yMinDirection, transform.position.z);
			}
		}
	}

}