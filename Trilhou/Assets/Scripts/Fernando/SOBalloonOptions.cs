using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonOptions", menuName = "ScriptableObject / BalloonOptions")]
public class SOBalloonOptions : ScriptableObject
{
    public List<string> ballonOptions;
    public string _name;
    public int ballonsCounter = 10;

    private void OnDisable()
    {
        ballonsCounter = 11;
    }

    public void AddWordsToBallonOptions()
    {
        ballonOptions.Clear();
        ballonOptions.Insert(0, "Quando?");
        ballonOptions.Insert(1, "Onde?");
        ballonOptions.Insert(1, "Quem?");
        ballonOptions.Insert(1, "Como?");
        ballonOptions.Insert(1, "De que maneira?");
        ballonOptions.Insert(1, "O que?");
        ballonOptions.Insert(1, "Por que?");
        ballonOptions.Insert(1, "Qual?");
        ballonOptions.Insert(1, "E se?");
        ballonOptions.Insert(1, "Quanto?");
        ballonOptions.Insert(1, "Que?");
    }
    public void RemoveFromList(string name)
    {
        ballonOptions.Remove(name);
        ballonsCounter--;
    }   
  
}
