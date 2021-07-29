using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(50, 50);
    [SerializeField] float jumpForce = 5f;
    Animator animator;
    bool runOnce = true;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * x, speed.y * y, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);

        if (x > 0 || y > 0 || y < 0 || x < 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdling", false);

        }
        else if(x == 0 && y == 0)
        {           
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            Invoke("SetJumpFalse", 1);
        }
    }

    string SetJumpFalse()
    {
        animator.SetBool("isIdling", true);
        return "false";
    }


}
