using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightHolder : MonoBehaviour
{
    bool canDrag = false;
    private void OnMouseDown()
    {
        canDrag = true;
    }

    private void OnMouseUp()
    {
        canDrag = false;
    }

    private void Update()
    {
        if (canDrag)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(position.x, position.y, 0);

        }
    }
}
