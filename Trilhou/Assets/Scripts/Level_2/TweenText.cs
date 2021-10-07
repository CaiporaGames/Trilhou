using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paulo
{
    public class TweenText : MonoBehaviour
    {
        [SerializeField] private float tweenTime;

        public void Tween()
        {
            LeanTween.cancel(gameObject);

            gameObject.transform.localScale = Vector3.one;

            LeanTween.scale(gameObject, Vector3.one * 1.5f, tweenTime).setEasePunch();
        }
    }
}