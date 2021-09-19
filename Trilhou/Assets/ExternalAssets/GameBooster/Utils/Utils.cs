using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster{

	[System.Serializable]
	public class BoolUnityEvent : UnityEngine.Events.UnityEvent<bool> {}
	[System.Serializable]
	public class IntUnityEvent : UnityEngine.Events.UnityEvent<int> {}
	[System.Serializable]
	public class FloatUnityEvent : UnityEngine.Events.UnityEvent<float> {}
	[System.Serializable]
	public class StringUnityEvent : UnityEngine.Events.UnityEvent<string> {}

	[System.Serializable]
	public class Vector2UnityEvent : UnityEngine.Events.UnityEvent<Vector2> {}
	[System.Serializable]
	public class Vector3UnityEvent : UnityEngine.Events.UnityEvent<Vector3> {}

	[System.Serializable]
	public class GameObjectUnityEvent : UnityEngine.Events.UnityEvent<GameObject> {}
	[System.Serializable]
	public class TransformUnityEvent : UnityEngine.Events.UnityEvent<Transform> {}
	[System.Serializable]
	public class Collider2DUnityEvent : UnityEngine.Events.UnityEvent<Collider2D> {}
	[System.Serializable]
	public class ColliderUnityEvent : UnityEngine.Events.UnityEvent<Collider> {}

}