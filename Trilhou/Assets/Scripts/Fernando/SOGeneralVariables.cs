using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / GeneralVariables ", fileName = "GeneralVariables ")]
public class SOGeneralVariables : ScriptableObject
{
    public bool gamePaused = false;
    public int pointsbarPoints;
    public int playerHearts = 3;

    private void OnDisable()
    {
        gamePaused = false;
    }
}
