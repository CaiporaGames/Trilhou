using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fernando
{

    public class JumpMaria : MonoBehaviour
    {
        public float force = 80f;
        public Rigidbody2D player;
        public bool goJump = false;
        public int jumpDouble = 2;
        public int displayText = 0;
        public int CountBaloonOn;
        public GameObject baloon;
        public GameObject window1;
        public GameObject window2;
        public GameObject window3;
        public GameObject boxText;
        public Text text;

        // Start is called before the first frame update
        void Start()
        {
            text.enabled = false;
            
            Instantiate(baloon, new Vector3(window1.transform.position.x, window1.transform.position.y, window1.transform.position.z), Quaternion.identity);
            Instantiate(baloon, new Vector3(window2.transform.position.x, window2.transform.position.y, window2.transform.position.z), Quaternion.identity);
            Instantiate(baloon, new Vector3(window3.transform.position.x, window3.transform.position.y, window3.transform.position.z), Quaternion.identity);
            CountBaloonOn = 3;
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
                CountBaloonOn--;
                if(CountBaloonOn <= 7)
                {

                    Instantiate(baloon, new Vector3(window1.transform.position.x, window1.transform.position.y, window1.transform.position.z), Quaternion.identity);
                    Instantiate(baloon, new Vector3(window2.transform.position.x, window2.transform.position.y, window2.transform.position.z), Quaternion.identity);
                    Instantiate(baloon, new Vector3(window3.transform.position.x, window3.transform.position.y, window3.transform.position.z), Quaternion.identity);
                    CountBaloonOn += 3;
                }
                
                displayText += 1;
                text.text = displayText.ToString();
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
