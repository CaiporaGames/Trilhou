using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster
{
    public class BaseReorderableList { }

    public class ReorderableList<T> : BaseReorderableList
    {
        [SerializeField]
        private List<T> list;

        public int Count { get { return list == null ? 0 : list.Count; } }

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

    }

    [System.Serializable] public class ListBool : ReorderableList<bool> { }
    [System.Serializable] public class ListInt : ReorderableList<int> { }
    [System.Serializable] public class ListFloat : ReorderableList<float> { }

    [System.Serializable] public class ListVector2 : ReorderableList<Vector2> { }
    [System.Serializable] public class ListVector3 : ReorderableList<Vector3> { }
    [System.Serializable] public class ListQuaternion : ReorderableList<Quaternion> { }
    [System.Serializable] public class ListString : ReorderableList<string> { }

    [System.Serializable] public class ListGameObject : ReorderableList<GameObject> { }
    [System.Serializable] public class ListTransform: ReorderableList<Transform> { }
    [System.Serializable] public class ListCollider : ReorderableList<Collider> { }
    [System.Serializable] public class ListCollider2D : ReorderableList<Collider2D> { }

}
