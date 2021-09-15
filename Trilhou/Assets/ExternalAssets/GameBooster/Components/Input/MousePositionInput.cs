using UnityEngine;
using System.Collections;

namespace GameBooster{

	[Comment(@"Gets mouse position")]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#mousepositioninput")]
	[AddComponentMenu("GameBooster/Input/MousePositionInput")]
	public class MousePositionInput : GameBoosterBehaviour {

		public enum PositionType { World2D, Screen, Viewport, CenteredViewport }
		[Tooltip(
@"Mouse position coordinate
-World2D: mouse position in the world coordinates using a orthographic camera
-Screen: absolute mouse position in the screen
-Viewport: mouse position relative to screen from (0,0) at botton left to (1,1) at top right
-CenteredViewport: mouse position relative to screen with (0,0) at screen center
	")]
		public PositionType positionType = PositionType.World2D;

		public Vector2UnityEvent actions;

		private Vector2 m_value;
		[InspectorDebugger]
		public Vector2 value { get { return m_value; } }

		void Update () {
			
			var mousePos = Input.mousePosition;

			switch (positionType) {
			case PositionType.Screen:
				actions.Invoke (m_value = (Vector2)mousePos);
				break;
			case PositionType.World2D:
				actions.Invoke (m_value = (Vector2)Camera.main.ScreenToWorldPoint (mousePos));
				break;
			case PositionType.Viewport:
				actions.Invoke (m_value = (Vector2)Camera.main.ScreenToViewportPoint (mousePos));
				break;
			case PositionType.CenteredViewport:
				actions.Invoke (m_value = (Vector2)Camera.main.ScreenToViewportPoint (mousePos)*2 - Vector2.one );
				break;
			}
		}
	}

}