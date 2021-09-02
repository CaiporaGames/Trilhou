using GameBooster;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo
{
    public class TreeShake : MonoBehaviour//This simulates a tree shaking on the wind.
    {
        [Tooltip("Controls the angle of rotation, if it is bigger the tree will shake strongly")]
        [SerializeField] float shakeAngle;
        [SerializeField] float shakeDuration;
        [Tooltip("This is the delay between animations, if you want that differents elements shake in different times")]
        [SerializeField] float delay;
        [Tooltip("This is used to make the shake more random between times")]
        [SerializeField] bool randomizeTheDelay = false;
        //If the randomizeTheDelay is true we can set different times for the shake efffect
        [SerializeField] float minRandomTime;
        [SerializeField] float maxRandomTime;


        // Start is called before the first frame update
        void Start()
        {
            if (randomizeTheDelay)
            {
                delay = Random.Range(minRandomTime, maxRandomTime);
            }

            LeanTween.rotateZ(gameObject, shakeAngle, shakeDuration).setEasePunch().setOnComplete(Shake).setDelay(delay);
        }


        void Shake()
        {
            LeanTween.rotateZ(gameObject, shakeAngle, shakeDuration).setEasePunch().setOnComplete(Start).setDelay(delay);
        }


    }
}
