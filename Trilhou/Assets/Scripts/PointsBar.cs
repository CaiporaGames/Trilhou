using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] float maxPoints = 10;
    [SerializeField] float lerpSpeed;

    AudioSource audioSource;
    float points = 0;
    int imageIndex;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Image image = images[imageIndex].GetComponent<Image>();
            Color imageColor = image.color;
            imageColor.a = 1;
            image.color = imageColor;             
            LeanTween.alpha(images[imageIndex].GetComponent<RectTransform>(), 1, lerpSpeed);
            LeanTween.scale(gameObject.GetComponent<RectTransform>(),
                gameObject.GetComponent<RectTransform>().localScale * 1.5f, 0.5f).setOnComplete(RestoreScale).setDelay(0.1f);
            audioSource.Play();
            imageIndex++;
        }
    }

    void RestoreScale()//restore the scale from the points bar
    {
        LeanTween.scale(gameObject.GetComponent<RectTransform>(),
             gameObject.GetComponent<RectTransform>().localScale / 1.5f, 0.5f);
    }



}
