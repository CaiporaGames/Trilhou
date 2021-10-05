using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool canDrag = false;
  
    private void FixedUpdate()
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
}
