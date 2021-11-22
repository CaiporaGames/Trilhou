using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BalloonOptions", menuName = "ScriptableObject / BalloonOptions")]
public class SOBalloonOptions : ScriptableObject
{
    public List<string> ballonOptions;
    public string _name;
    public int ballonsCounter = 4;

    private void OnDisable()
    {
        ballonsCounter = 4;
    }

    public void AddWordsToBallonOptions()
    {
        ballonOptions.Clear();
        ballonOptions.Insert(0, "O assunto � interessante? ");
        ballonOptions.Insert(1, "O assunto atende a tarefa solicitada pelo professor?");
        ballonOptions.Insert(2, "Existem informa��es suficientes sobre esse assunto na biblioteca e na internet? ");
        ballonOptions.Insert(3, "Posso organizar as informa��es para apresentar no prazo que o professor pediu?");     
    }
    public void RemoveFromList(string name)
    {
        ballonOptions.Remove(name);
        ballonsCounter--;
    }   
  
}
