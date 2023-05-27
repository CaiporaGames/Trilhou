using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fernando
{
        public class Move2D : MonoBehaviour
    {
        // Start is called before the first frame update
        public Rigidbody2D rb;
        public int moveSpeed;
        private float direction;

        private Vector3 facingRight;
        private Vector3 facingLeft;

        public bool inFloor; // em contato com o chao
        public Transform detectFloor; // detectar o chao
        public LayerMask isFloor; // identificar o chao

        void Start()
        {
            facingRight = transform.localScale;
            facingLeft = transform.localScale;
            facingLeft.x = facingLeft.x * -1;

            rb = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            inFloor = Physics2D.OverlapCircle(detectFloor.position, 0.2f, isFloor);

            if (Input.GetButtonDown("Jump") && inFloor == true)
            {
                rb.velocity = Vector2.up * 20;
            }

            direction = Input.GetAxis("Horizontal");

            if (direction > 0)
            {
                //olhando para a direita
                transform.localScale = facingRight;
            }
            if (direction < 0)
            {
                //olhando para a esquerda
                transform.localScale = facingLeft;
            }

            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
    }
}
