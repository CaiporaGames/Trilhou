using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMovement : MonoBehaviour//This make the decent movement
{
    [Header("Vertical Movement")]
    [SerializeField] AnimationCurve yCurve;
    [SerializeField] float yDistance;
    [SerializeField] float yTimer;

    [Header("Horizontal Movement")]
    [SerializeField] AnimationCurve xCurve;
    [SerializeField] float xDistance;
    [SerializeField] float xTimer;


    [Header("Scaler Movement")]
    [SerializeField] float scaler;
    [SerializeField] float scaleTimer;


    [Header("Rotate Movement")]
    [SerializeField] float angle;
    [SerializeField] float rotateTimer;
    [SerializeField] float delayToStart;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(gameObject, yDistance, yTimer).setEase(yCurve);
        LeanTween.moveLocalX(gameObject, xDistance, xTimer).setEase(xCurve);
        LeanTween.scale(transform.GetChild(0).gameObject, new Vector3(scaler, scaler, scaler), scaleTimer);
        LeanTween.rotateX(transform.GetChild(0).gameObject, angle, rotateTimer).setDelay(delayToStart).setOnComplete(DestroyThis);        
    }   

    void DestroyThis()
    {
        Destroy(this);
    }
}
