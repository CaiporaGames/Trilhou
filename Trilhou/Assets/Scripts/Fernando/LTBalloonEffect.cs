using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTBalloonEffect : MonoBehaviour
{

    [SerializeField] AnimationCurve curve;
    // Start is called before the first frame update
    public void StartEffect()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1).setEase(curve).setOnComplete(DestoyThis);
    }   

    void DestoyThis()
    {
        Destroy(gameObject);
    }
}
