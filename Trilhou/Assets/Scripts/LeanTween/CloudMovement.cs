using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class CloudMovement : MonoBehaviour
    {
        [Header("Horizontal Movement")]
        [Tooltip("How much the player is moving in the x direction")]
        [SerializeField] float xDirection;
        [Tooltip("Time in seconds between cicle repetition")]
        [SerializeField] float timeBetweenCicles;
        [Tooltip("Time in seconds before cicle start or restart")]
        [SerializeField] float delayBetweenCicles;
        [SerializeField] float minDelayTime;
        [SerializeField] float maxDelayTime;

        [Header("Vertical Movement")]
        [Tooltip("How much the cloud must go up to disappear from screen")]
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
