using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinocularZoom : MonoBehaviour
{
    [SerializeField] Transform sprite;
    [SerializeField] float minZoom = 10;
    [SerializeField] float maxZoom = 15;

    float zoom;   

    // Update is called once per frame
    void Update()
    {
        zoom = Input.mouseScrollDelta.y;
        sprite.localScale = new Vector3(sprite.localScale.x + zoom, sprite.localScale.y + zoom, 1);

        if (sprite.localScale.x < minZoom)//Do not need the z because it is connected with the x
        {

            sprite.localScale = new Vector3(minZoom, minZoom, 1);
        }
        if (sprite.localScale.x > maxZoom)
        {

            sprite.localScale = new Vector3(maxZoom, maxZoom, 1);
        }
    }
}
