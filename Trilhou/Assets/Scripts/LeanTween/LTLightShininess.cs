using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTLightShininess : MonoBehaviour
{
    [SerializeField] float alphaAmount;
    [SerializeField] float time;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(gameObject, alphaAmount, time).setLoopPingPong() ;
    }   
}
