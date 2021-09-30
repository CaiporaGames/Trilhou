using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Timoteo
{
    //A round circle will goes from one screen side to another
    public class LTRoundTransition : MonoBehaviour
    {

        static LTRoundTransition _instance;
        public static LTRoundTransition Instance { get { return _instance; } }

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

        public void StartTransitionLoader(Vector3 startPosition, Vector3 middlePosition, float time)
        {
            LeanTween.move(gameObject, middlePosition, 0);
            LeanTween.move(gameObject, startPosition, time);
        }

        public void EndTransitionLoader(System.Action m, Vector3 startPosition, Vector3 middlePosition, float time)
        {
            LeanTween.move(gameObject, startPosition, 0);
            LeanTween.move(gameObject, middlePosition, time).setDelay(3).setOnComplete(m);
        }
    }
}
