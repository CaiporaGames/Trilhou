using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameBooster
{

    public class ReorderableExample : MonoBehaviour
    {
        public int x;

        [System.Serializable]
        public class MyClass
        {
            public string name;
            [Range(0, 1)]
            public float s;
            public bool b;
        }

        [System.Serializable]
        public class MyClass2
        {
            public string name;
            public ListInt values;
        }


        [System.Serializable] public class ReList_MyClass : ReorderableList<MyClass> { }
        [System.Serializable] public class ReList_MyClass2 : ReorderableList<MyClass2> { }

        public ListInt myList;
        public ListString myArray;
        public ReList_MyClass myClassArray;

        public MyClass2 myClass2;

        public ReList_MyClass2 myClass2List;

    }

}