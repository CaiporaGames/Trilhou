using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Timoteo
{
    //COntrols the dialogue system. 
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] SODialogue dialogues;//This is a scriptable object holding the dialogue
        [SerializeField] TMP_Text dialogueText;//this holds the text component 

        [Tooltip("This holds the current sentence index on the sentences string list")]
        public int setenceIndex;

        private void Start()
        {
            DisplayDialogue(0);
        }

        void DisplayDialogue(int setenceIndex)//this passes the dialogue from the scriptable object dialogues to the text
        {
            dialogueText.text = dialogues.setences[setenceIndex].setences;

        }

        public void NextDialogue()//this controls the next dialogue when the player press the next button
        {
            if (setenceIndex < dialogues.setences.Length - 1)
            {
                setenceIndex++;
                DisplayDialogue(setenceIndex);
            }
        }

        public void BackDialogue()//this controls the last dialogue when the player press the back button
        {
            if (setenceIndex > 0)
            {
                setenceIndex--;
                DisplayDialogue(setenceIndex);
            }
        }

    }
}