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
        public byte setenceIndex;

        public byte SentenceIndex { get { return setenceIndex; } }

        static DialogueManager _instance;
        public static DialogueManager Instance { get { return _instance; } }

        public delegate void nextDialogueDelegate();
        public static nextDialogueDelegate NextDialogueDelegate;//it is called everytime the player press the next button
        public delegate void lastDialogueIndexDelegate();
        public static lastDialogueIndexDelegate lastDialogueIndex;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
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
            LastDialogueIndex();

            if (setenceIndex < dialogues.setences.Length - 1)
            {
                setenceIndex++;
                NextDialogueDelegate?.Invoke();
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

        void LastDialogueIndex()
        {
            if (setenceIndex == dialogues.setences.Length-1)
            {
                lastDialogueIndex?.Invoke();
            }
        }

    }
}