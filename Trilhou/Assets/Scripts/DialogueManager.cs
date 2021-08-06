using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] SODialogue dialogues;
    [SerializeField] TMP_Text dialogueText;

    [Tooltip("This holds the current sentence index on the sentences string list")]
    public int setenceIndex;

    private void Start()
    {
        DisplayDialogue(0);
    }

    void DisplayDialogue(int setenceIndex)
    {
        dialogueText.text = dialogues.setences[setenceIndex].setences;
    
    }

    public void NextDialogue()
    {
        if (setenceIndex < dialogues.setences.Length - 1)
        {
                setenceIndex++;
            DisplayDialogue(setenceIndex);
        }
    }

    public void BackDialogue()
    {
        if (setenceIndex > 0)
        {
            setenceIndex--;
            DisplayDialogue(setenceIndex);
        }       
    }

}
