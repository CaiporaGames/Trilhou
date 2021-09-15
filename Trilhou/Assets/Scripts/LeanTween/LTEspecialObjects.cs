using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTEspecialObjects : MonoBehaviour
{
    [SerializeField] Vector3 scaler;
    [SerializeField] float time;
    [SerializeField] GameObject effect;

    Collider2D _collider;
    AudioSource _audio;
    SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _audio = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        _collider.enabled = false;
        _audio.Play();
        _renderer.sortingOrder = 20;
        LeanTween.scale(gameObject, scaler, time).setOnComplete(DestroyThis);
        LeanTween.move(gameObject, new Vector3(0, 0, 0), time);
        GameObject instance = Instantiate(effect, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
    }
    
    void DestroyThis()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject, 3);
    }
}
