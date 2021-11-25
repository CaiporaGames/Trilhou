using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTRotateCard : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        LeanTween.rotateY(gameObject, 180, 2);
        audioSource.Play();
    }  
}
