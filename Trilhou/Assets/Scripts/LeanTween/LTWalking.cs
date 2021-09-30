using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTWalking : MonoBehaviour
{
    [SerializeField] Transform finalPosition;
    [SerializeField] float time;
    [Tooltip("Delay between characters")]
    [SerializeField] float delay;

    //[Tooltip("Sets the size the characters need to resize")]
   // [SerializeField] Vector3 scaler;

    private void Start()
    {
        LeanTween.move(gameObject, finalPosition.position, time).setDelay(delay);
        //LeanTween.scale(gameObject, scaler, time).setDelay(delay);
    }
}
