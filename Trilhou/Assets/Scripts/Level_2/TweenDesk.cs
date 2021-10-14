using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Paulo
{
    public class TweenDesk : MonoBehaviour
    {
        [SerializeField] private float localX;
        [SerializeField] private float localY;
        [SerializeField] private float velocity;

        private float elapsedTime;
        private Vector3 position;
        private bool isPlaying;

        void Start()
        {
            isPlaying = false;
            elapsedTime = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (isPlaying)
            {
                elapsedTime = elapsedTime + Time.deltaTime;
                if (Math.Round(elapsedTime) % 3 == 0 && Math.Round(elapsedTime) % 6 == 0)
                {
                    position = gameObject.transform.position;
                    position.x -= localX;
                    position.y -= localY;
                    LeanTween.move(gameObject, position, velocity);
                }
                else if (Math.Round(elapsedTime) % 3 == 0 && Math.Round(elapsedTime) % 6 != 0)
                {
                    position = gameObject.transform.position;
                    position.x += localX;
                    position.y += localY;
                    LeanTween.move(gameObject, position, velocity);
                }
            }
        }

        public void StartMove()
        {
            Debug.Log("começou");
            isPlaying = true;
            //MoveDesks();
        }
        public void StopMove()
        {
            isPlaying = false;
        }

        private IEnumerator MoveDesks()
        {
            while (isPlaying)
            {
                elapsedTime = elapsedTime + Time.deltaTime;
                if (Math.Round(elapsedTime) % 3 == 0 && Math.Round(elapsedTime) % 6 == 0)
                {
                    position = gameObject.transform.position;
                    position.x -= localX;
                    position.y -= localY;
                    LeanTween.move(gameObject, position, velocity);
                }
                else if (Math.Round(elapsedTime) % 3 == 0 && Math.Round(elapsedTime) % 6 != 0)
                {
                    position = gameObject.transform.position;
                    position.x += localX;
                    position.y += localY;
                    LeanTween.move(gameObject, position, velocity);
                }

                yield return null;
            }

        }
    }
}