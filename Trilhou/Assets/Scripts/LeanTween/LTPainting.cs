using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTPainting : MonoBehaviour
{
    [SerializeField] Vector3 strangth;
    [SerializeField] Vector3 position;
    [SerializeField] float time;
    [SerializeField] GameObject effect;

    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        LeanTween.rotate(gameObject, strangth, time).setEasePunch();

        if (effect != null)
        {
            GameObject instance = Instantiate(effect, transform.position + position, Quaternion.identity);
            Destroy(instance, 2);
        }
        _audio.Play();
    }

}
