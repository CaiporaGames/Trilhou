using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster {

	[Comment(
@"Transform extra methods

Methods and properties to set only one axis of position/scale/rotation and copy position/scale/rotation from other transform.

Properties:
	float positionX
	float positionY
	float positionZ
	float localPositionX
	float localPositionY
	float localPositionZ
	Vector2 positionXY
	Vector2 localPositionXY
	float localScaleX
	float localScaleY
	float localScaleZ
	float eulerAnglesX
	float eulerAnglesY
	float eulerAnglesZ
	float localEulerAnglesX
	float localEulerAnglesY
	float localEulerAnglesZ

Methods:
	//copy position from target transform
	void SetPositionFrom(Transform target)

	//copy localPosition from target transform
	void SetLocalPositionFrom(Transform target)

	//copy rotation from target transform
	void SetRotationFrom(Transform target)

	//copy localRotation from target transform
	void SetLocalRotationFrom(Transform target)

	//copy localScale from target transform
	void SetLocalScaleFrom(Transform target)"
	)]
	[HelpURL("https://raphaelmarques2.github.io/GameBoosterDocs/#transformmethods")]
	[AddComponentMenu("GameBooster/Basics/TransformMethods")]
	public class TransformMethods : GameBoosterBehaviour {

		public float positionX { set { SetPositionAxis (0, value, false); } }
		public float positionY { set { SetPositionAxis (1, value, false); } }
		public float positionZ { set { SetPositionAxis (2, value, false); } }

		public float localPositionX { set { SetPositionAxis (0, value, true); } }
		public float localPositionY { set { SetPositionAxis (1, value, true); } }
		public float localPositionZ { set { SetPositionAxis (2, value, true); } }

		public Vector2 positionXY { set { transform.position = value; } }
		public Vector2 localPositionXY { set { transform.localPosition = value; } }

		public float localScaleX { set { SetScaleAxis (0, value); } }
		public float localScaleY { set { SetScaleAxis (1, value); } }
		public float localScaleZ { set { SetScaleAxis (2, value); } }

		public float eulerAnglesX { set { SetEulerAnglesAxis(0,value,false); } }
		public float eulerAnglesY { set { SetEulerAnglesAxis(1,value,false); } }
		public float eulerAnglesZ { set { SetEulerAnglesAxis(2,value,false); } }

		public float localEulerAnglesX { set { SetEulerAnglesAxis(0,value,true); } }
		public float localEulerAnglesY { set { SetEulerAnglesAxis(1,value,true); } }
		public float localEulerAnglesZ { set { SetEulerAnglesAxis(2,value,true); } }


		public void SetPositionFrom(Transform target){
			transform.position = target.position;
		}
		public void SetLocalPositionFrom(Transform target){
			transform.localPosition = target.localPosition;
		}
		public void SetRotationFrom(Transform target){
			transform.rotation = target.rotation;
		}
		public void SetLocalRotationFrom(Transform target){
			transform.localRotation = target.rotation;
		}
		public void SetLocalScaleFrom(Transform target){
			transform.localScale = target.localScale;
		}


		private void SetPositionAxis(int axisIndex, float value, bool local){
			var pos = local ? transform.localPosition : transform.position;
			pos [axisIndex] = value;
			if (local) {
				transform.localPosition = pos;
			} else {
				transform.position = pos;
			}
		}

		private void SetScaleAxis(int axisIndex, float value){
			var scale = transform.localScale;
			scale[axisIndex] = value;
			transform.localScale = scale;
		}

		private void SetEulerAnglesAxis(int axisIndex, float value, bool local){
			var angles = local ? transform.localEulerAngles : transform.eulerAngles;
			angles[axisIndex] = value;
			if (local) {
				transform.localEulerAngles = angles;
			} else {
				transform.eulerAngles = angles;
			}
		}

	}

}
