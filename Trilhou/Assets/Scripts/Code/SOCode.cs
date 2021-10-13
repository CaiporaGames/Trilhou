using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Code", menuName = "ScriptableObject / Code")]
public class SOCode : ScriptableObject
{
   public string[] codes = new string[10];
   public int levelIndex = 0;
}
