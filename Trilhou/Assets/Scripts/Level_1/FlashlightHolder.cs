using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHolder : MonoBehaviour
{
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    bool canDrag = false;

   
    private void OnMouseDown()
    {
        canDrag = true;
    }

    private void OnMouseUp()
    {
        canDrag = false;
    }

    private void FixedUpdate()
    {
        if (canDrag)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if (position.y > -yOffset && position.y < yOffset && position.x > -xOffset && position.x < xOffset)
            {
                transform.position = new Vector3(position.x, position.y, 0);
            }
            else if(position.y < 0 && position.x > -xOffset && position.x < xOffset)
            {
                transform.position = new Vector3(position.x, -yOffset, 0);
            }
            else if (position.y > 0 && position.x > -xOffset && position.x < xOffset)
            {
                transform.position = new Vector3(position.x , yOffset, 0);
            }
            else if (position.x < 0 && position.y > -yOffset && position.y < yOffset)
            {
                transform.position = new Vector3(-xOffset, position.y, 0);
            }
            else if (position.x > 0 && position.y > -yOffset && position.y < yOffset)
            {
                transform.position = new Vector3(xOffset, position.y, 0);
            }

        }
    }
}
