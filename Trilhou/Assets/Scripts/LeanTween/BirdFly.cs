using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour//This simulates a bird flying from left to right on distance.
{
    [Tooltip("This controls how far the bird can fly in the x direction")]
    [SerializeField] float xDistance;
    [Tooltip("This is how long the bird will takes to complete the first circle from left to right or right to left")]
    [SerializeField] float clicleTimer;
    [Tooltip("This is the time between the left to right and right to left movement. Specify this to make the bird wait till restart the cicle")]
    [SerializeField] float delay;
    [SerializeField] float minDelayTime;
    [SerializeField] float maxDelayTime;

    void Start()//Left to right movement
    {
        LeanTween.rotateY(gameObject, 180, 0.5f);
        delay = Random.Range(minDelayTime, maxDelayTime);
        LeanTween.moveX(gameObject, xDistance, clicleTimer).setOnComplete(RightToLeft).setDelay(delay);
    }

    void RightToLeft()
    {
        LeanTween.rotateY(gameObject, 0, 0.5f);
        delay = Random.Range(minDelayTime, maxDelayTime);
        LeanTween.moveX(gameObject, -xDistance, clicleTimer).setOnComplete(Start).setDelay(delay);
    }

   
}
