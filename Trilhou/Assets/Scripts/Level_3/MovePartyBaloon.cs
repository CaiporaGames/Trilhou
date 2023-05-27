using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fernando
{

    public class MovePartyBaloon : MonoBehaviour
    {
        public float vel = 2.5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                Destroy(transform.gameObject);

            }
        }
    }

}
