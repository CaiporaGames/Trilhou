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
        [SerializeField] float lerpSpeed;
        [SerializeField] SOGeneralVariables generalVariables;

        static PointsBar instance;
        public static PointsBar Instance { get { return instance; } }

        AudioSource audioSource;
        int imageIndex;

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

            imageIndex = generalVariables.pointsbarPoints;
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();

            for (int i = 0; i < generalVariables.pointsbarPoints; i++)
            {
                Image image = images[i].GetComponent<Image>();
                Color imageColor = image.color;
                imageColor.a = 1;
                image.color = imageColor;
            }
        }
    

        public void AddPointsToBar()//this will add a point on the points bar.
        {
            if (generalVariables.pointsbarPoints == images.Length)
            {
                return;
            }
            generalVariables.pointsbarPoints++;

           
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