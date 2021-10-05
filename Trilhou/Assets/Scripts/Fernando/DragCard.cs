using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] SOBalloonOptions options;

    bool canDrag = false;
    TextMeshProUGUI cardText;
    TextMeshProUGUI otherCardText;
    bool runOnce = true;


    private void Start()
    {
        cardText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (canDrag)
        {
            transform.position = Input.mousePosition;
        }
    }  

    public void OnPointerDown(PointerEventData eventData)
    {
        canDrag = true;
        LeanTween.scale(gameObject, new Vector3(1f,0.5f,1), 0.5f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canDrag = false;
        LeanTween.scale(gameObject, new Vector3(2f, 1f, 1), 0.5f);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!canDrag && runOnce)
        {
            runOnce = false;
            otherCardText = collision.GetComponentInChildren<TextMeshProUGUI>();

            if (cardText.text == otherCardText.text)
            {
                options.RemoveFromList(cardText.text);
                //Put some effects here
            }
            else
            {
                Debug.Log("Wrong answer. Try again");
            }
        }
    }
}
