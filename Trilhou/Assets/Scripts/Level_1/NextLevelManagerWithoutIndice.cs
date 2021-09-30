using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Timoteo
{
    //This is used when we do not need to use the indice from the dialogue manager
    public class NextLevelManagerWithoutIndice : MonoBehaviour
    {
        [Tooltip("This is on the canvas left side")]
        [SerializeField] Transform startPosition;//This check points are on the canvas hight and width
        [Tooltip("This is on the middle of the canvas")]
        [SerializeField] Transform middlePosition;
        [Tooltip("How long the animation will takes")]
        [SerializeField] float time;

        static NextLevelManagerWithoutIndice _instance;
        public static NextLevelManagerWithoutIndice Instance { get { return _instance; } }

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

        public void NextLevel()
        {
            LTRoundTransition.Instance.EndTransitionLoader(LoadLevel, startPosition.position, middlePosition.position, time);
        }

        public void LoadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
