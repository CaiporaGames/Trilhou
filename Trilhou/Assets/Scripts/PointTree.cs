using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointTree : MonoBehaviour
{
    [SerializeField] float distanceToMove = 1f;
    [SerializeField] float animationDuration = 1f;
    [SerializeField] float timerBetweenShakes = 1f;
    [SerializeField] GameObject panel;
    bool runOnce = true;
    bool isClicked = false;
    float maxTimerBetweenShakes = 1f;
    

    Transform coconutPosition;

    private void Start()
    {
        coconutPosition = transform;
    }

    private void OnMouseDown()
    {
        if (runOnce)
        {
            runOnce = false;
            isClicked = true;
            LeanTween.move(gameObject,new Vector3(transform.position.x, transform.position.y - distanceToMove, 0), animationDuration);

           
        }
    }

    private void Update()
    {
        timerBetweenShakes -= Time.deltaTime;
    }

    private void OnMouseEnter()
    {
        if (!isClicked && timerBetweenShakes <= 0)
        {
            timerBetweenShakes = maxTimerBetweenShakes;
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(0,0.5f,0), 0.3f).setEasePunch();
            
        }
        if (isClicked)
        {
            panel.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (isClicked)
        {
            panel.SetActive(false);
        }
    }
}
