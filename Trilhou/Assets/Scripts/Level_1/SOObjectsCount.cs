using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsCount", menuName = "ScriptableObject / ObjectsCount")]
public class SOObjectsCount : ScriptableObject
{
    public int objectsCount = 0;

    private void OnEnable()
    {
        objectsCount = 0;
    }
}
