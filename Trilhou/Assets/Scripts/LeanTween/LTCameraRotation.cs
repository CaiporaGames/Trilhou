using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTCameraRotation : MonoBehaviour
{
    [SerializeField] float rotationAngle;
    [SerializeField] float durationTime;
    [SerializeField] float totalMovementDuration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopRotation(totalMovementDuration));
        LeanTween.rotateY(gameObject, rotationAngle, durationTime).setLoopPingPong();
    }  

    IEnumerator StopRotation(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        LeanTween.cancel(gameObject);
    }

}
