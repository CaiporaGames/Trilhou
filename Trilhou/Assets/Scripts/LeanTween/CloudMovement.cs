using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class CloudMovement : MonoBehaviour
    {
        [Header("Horizontal Movement")]
        [SerializeField] float xDirection;
        [SerializeField] float timeBetweenCicles;
        [SerializeField] float delayBetweenCicles;
        [SerializeField] float minDelayTime;
        [SerializeField] float maxDelayTime;

        [Header("Vertical Movement")]
        [SerializeField] float yDirection;
        void Start()//Left to right movement
        {
            delayBetweenCicles = Random.Range(minDelayTime, maxDelayTime);
            LeanTween.moveX(gameObject, xDirection, timeBetweenCicles).setDelay(delayBetweenCicles).setOnComplete(UpMovement);
        }

        void UpMovement()//This is make to get the cloud from the window in the vertical direction
        {
            LeanTween.moveY(gameObject, transform.position.y + yDirection, 0.5f).setOnComplete(BackMovement);
        }

        void BackMovement()//This is make to the cloud go back to the x initial position.
        {
            delayBetweenCicles = Random.Range(minDelayTime, maxDelayTime);
            LeanTween.moveX(gameObject, -xDirection, 0.5f).setOnComplete(DownMovement);
        }

        void DownMovement()//This is to go back to the x position
        {
            LeanTween.moveY(gameObject, transform.position.y - yDirection, 0.5f).setOnComplete(Start);
        }
    }
}
