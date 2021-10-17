using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTBalloonEffect : MonoBehaviour
{

    [SerializeField] AnimationCurve curve;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void StartEffect()
    {
        audioSource.Play();
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1).setEase(curve).setOnComplete(DestoyThis);
    }   

    void DestoyThis()
    {
        Destroy(gameObject);
    }
}
