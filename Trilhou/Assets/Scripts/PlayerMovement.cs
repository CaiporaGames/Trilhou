using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(50, 50);

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * x, speed.y * y, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
}
