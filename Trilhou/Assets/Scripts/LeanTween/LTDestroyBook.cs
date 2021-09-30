using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTDestroyBook : MonoBehaviour
{
    [SerializeField] Vector3 scaler;
    [SerializeField] float time;
    [SerializeField] GameObject effect;

    Collider2D _collider;
    AudioSource _audio;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        _collider.enabled = false;
        _audio.Play();
        LeanTween.scale(gameObject, scaler, time).setEasePunch().setOnComplete(DestroyThis);
        GameObject instance = Instantiate(effect, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
    }

    void DestroyThis()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject, 3);
    }
}
