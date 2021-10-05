using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonOptions", menuName = "ScriptableObject / BalloonOptions")]
public class SOBalloonOptions : ScriptableObject
{
    public List<string> ballonOptions;
    public string _name;

    public void RemoveFromList(string name)
    {
        ballonOptions.Remove(name);
        Debug.Log(ballonOptions.Count);
    }

    private void OnDisable()
    {
        ballonOptions[0] = "Quando?";
        ballonOptions[1] = "Onde?";
    }
}
