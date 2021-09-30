using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fernando
{

    public class JumpMaria : MonoBehaviour
    {
        public float force = 800f;
        public Rigidbody2D player;
        public bool goJump = false;
        public int jumpDouble = 3;
        public int displayText = 1;
        public GameObject baloon;
        public GameObject window;
        public GameObject boxText;
        public Text text;

        // Start is called before the first frame update
        void Start()
        {
            text.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(jumpDouble > 0 | goJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    player.AddForce(new Vector2(0, force * Time.deltaTime), ForceMode2D.Impulse);
                    jumpDouble--;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                jumpDouble = 2;
                goJump = true;
            }

            if (collision.gameObject.CompareTag("PartyBaloon"))
            {
                Destroy(collision.gameObject);
                Instantiate(baloon, new Vector3(window.transform.position.x, window.transform.position.y, window.transform.position.z), Quaternion.identity);
                displayText += 10;
                text.enabled = true;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                goJump = false;
            }
        }
        
    }

}
