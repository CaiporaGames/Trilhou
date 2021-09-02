using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class ButterFly : MonoBehaviour//This simulates a butterfly fly
    {
        [Header("Horizontal Movement")]
        [SerializeField] AnimationCurve curve;
        [SerializeField] float xDistance;
        [Tooltip("How much time the butterfly will takes to complete the horizontal movement")]
        [SerializeField] float horizontalFlyTimer;
       
        [Space(10)]

        [Header("Vertical Movement")]
        [Tooltip("How high the butterfly can go")]
        [SerializeField] float yDistance;
        [Tooltip("How much time the butterfly will takes to complete the vertical movement")]
        [SerializeField] float verticalFlyMovement;


        // Start is called before the first frame update
        void Start()
        {
            LeanTween.moveX(gameObject, xDistance, horizontalFlyTimer).setLoopPingPong().setEase(curve);//.setDestroyOnComplete();
            LeanTween.moveY(gameObject, yDistance, verticalFlyMovement).setLoopPingPong();
        }
       
    }
}