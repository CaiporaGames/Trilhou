using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timoteo
{
    //This controls the bar of points
    public class PointsBar : MonoBehaviour
    {
        [SerializeField] Image[] images;
        [SerializeField] float maxPoints = 10;
        [SerializeField] float lerpSpeed;

<<<<<<< HEAD
        static PointsBar instance;
        public static PointsBar Instance { get { return instance; } }

=======
>>>>>>> parent of e16a5a9 (excluir assets)
        AudioSource audioSource;
        float points = 0;
        int imageIndex;

<<<<<<< HEAD
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

=======
>>>>>>> parent of e16a5a9 (excluir assets)
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))//This is just for testing purpose
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

<<<<<<< HEAD
        public void AddPointsToBar()//this will add a point on the points bar.
=======
        public void AddToPointsBar()//this will add a point on the points bar.
>>>>>>> parent of e16a5a9 (excluir assets)
        {
            Image image = images[imageIndex].GetComponent<Image>();
            Color imageColor = image.color;
            imageColor.a = 1;
            image.color = imageColor;
            LeanTween.alpha(images[imageIndex].GetComponent<RectTransform>(), 1, lerpSpeed);
            LeanTween.scale(gameObject.GetComponent<RectTransform>(),
                gameObject.GetComponent<RectTransform>().localScale * 1.5f, 0.5f).setOnComplete(RestoreScale).setDelay(0.1f);//animate the bar when the player get a point
            audioSource.Play();
            imageIndex++;
        }

        void RestoreScale()//restore the scale from the points bar.
        {
            LeanTween.scale(gameObject.GetComponent<RectTransform>(),
                 gameObject.GetComponent<RectTransform>().localScale / 1.5f, 0.5f);
        }

    }
}