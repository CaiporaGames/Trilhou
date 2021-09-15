using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTTomada : MonoBehaviour
{
    AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();   
    }

    private void OnMouseDown()
    {
        _audio.Play();
    }
}
