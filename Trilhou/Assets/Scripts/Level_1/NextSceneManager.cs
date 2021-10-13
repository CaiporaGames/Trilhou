using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timoteo {
    public class NextSceneManager : MonoBehaviour
    {
        [Tooltip("In which dialogue index we need change level")]
        [SerializeField] int dialogueIndex;
        [Tooltip("This is on the canvas left side")]
        [SerializeField] Transform startPosition;//This check points are on the canvas hight and width
        [Tooltip("This is on the middle of the canvas")]
        [SerializeField] Transform middlePosition;
        [Tooltip("How long the animation will takes")]
        [SerializeField] float time;

        bool runOnce = true;


        private void Start()
        {
            LTRoundTransition.Instance.StartTransitionLoader(startPosition.position, middlePosition.position, time);
        }

        public void NextLevel()
        {
            if (dialogueIndex - 1 == DialogueManager.Instance.setenceIndex && runOnce)
            {
                runOnce = false;
                LTRoundTransition.Instance.EndTransitionLoader(LoadLevel, startPosition.position, middlePosition.position, time);
            }
        }        
       

        public void LoadLevel()
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }       
    }
}