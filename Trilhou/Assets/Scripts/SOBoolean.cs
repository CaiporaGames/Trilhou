using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boolean", menuName = "ScriptableObjects / Boolean")]
public class SOBoolean : ScriptableObject
{

    public bool boolean = true;
    private void OnDisable()
    {
        boolean = true;
    }
}
