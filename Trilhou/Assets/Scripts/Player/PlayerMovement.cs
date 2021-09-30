using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Timoteo
{
    //This is a simple player movement. This plays the player animations too. It will probabily change in the future.
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] Vector2 speed = new Vector2(50, 50);
        [SerializeField] float jumpForce = 5f;
        [Tooltip("This timer is to play different idle animations")]
        [SerializeField] float maxTimerBetweenIdleAnimation = 15;


        //   [Private Variables]
        Animator animator;
        bool runOnce = true;
        float timerBetweenIdleAnimation;


        private void Start()
        {
            animator = GetComponentInChildren<Animator>();          
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            timerBetweenIdleAnimation -= Time.deltaTime;
        }


        void Movement()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(speed.x * x, speed.y * y, 0);

            movement *= Time.deltaTime;

            transform.Translate(movement);

            if (x > 0 && y > 0 || x < 0 && y > 0)
            {
                animator.SetBool("backwalk", true);
                animator.SetBool("frontwalk", false);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", false);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);


            }
            else if (x < 0 && y < 0 || x > 0 && y < 0)
            {
                animator.SetBool("backwalk", false);
                animator.SetBool("frontwalk", true);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", false);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);


            }
            else if (x > 0 && y == 0)
            {
                animator.SetBool("backwalk", false);
                animator.SetBool("frontwalk", false);
                animator.SetBool("leftwalk", true);
                animator.SetBool("rightwalk", false);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);


            }
            else if (x < 0 && y == 0)
            {
                animator.SetBool("backwalk", false);
                animator.SetBool("frontwalk", false);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", true);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);


            }
            else if (x == 0 && y > 0)
            {
                animator.SetBool("backwalk", true);
                animator.SetBool("frontwalk", false);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", false);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);


            }
            else if (x == 0 && y < 0)
            {
                animator.SetBool("backwalk", false);
                animator.SetBool("frontwalk", true);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", false);

                animator.SetBool("idle1", false);
                animator.SetBool("idle2", false);

            }
            else if (x == 0 && y == 0)
            {
                animator.SetBool("backwalk", false);
                animator.SetBool("frontwalk", false);
                animator.SetBool("leftwalk", false);
                animator.SetBool("rightwalk", false);


               if (timerBetweenIdleAnimation <= 0)
               {
                    animator.SetBool("idle1", false);
                    animator.SetBool("idle2",true);
                    StartCoroutine(AnimationTimer(2.4f));
               }
               else
               {
                    animator.SetBool("idle1", true);
               }
            }
        }

        IEnumerator AnimationTimer(float timer)
        {
            yield return new WaitForSeconds(timer);
            timerBetweenIdleAnimation = maxTimerBetweenIdleAnimation;
            animator.SetBool("idle2", false);
        }
    }

   
}
