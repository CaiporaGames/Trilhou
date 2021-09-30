using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timoteo
{
    public class LTBinoculoFollowPath : MonoBehaviour
    {
        [Tooltip("This has all the position that the binoculo need to go")]
        [SerializeField] Transform[] nextPosition;
        [SerializeField] float time;
        [SerializeField] float delay;

        [Header("Setting up of transition scene")]
        
        [Tooltip("This is on the canvas left side")]
        [SerializeField] Transform startPosition;//This check points are on the canvas hight and width
        [Tooltip("This is on the middle of the canvas")]
        [SerializeField] Transform middlePosition;
        [Tooltip("How long the animation will takes")]
        [SerializeField] float transitionTime;


        int i = 0;

        private void Awake()
        {
           // LTRoundTransition.Instance.StartTransitionLoader(startPosition.position, middlePosition.position, transitionTime);

        }
        // Start is called before the first frame update
        void Start()
        {
            if (i == nextPosition.Length)
            {
                LTRoundTransition.Instance.EndTransitionLoader(LoadLevel, startPosition.position, middlePosition.position, transitionTime);
               return;
            }
            LeanTween.move(gameObject, nextPosition[i], time).setDelay(delay).setOnComplete(Start);
           
            if (i == 4)
            {
                delay = 0;
                time = time - 2;
            }
            i++;
        }      

        public void LoadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}