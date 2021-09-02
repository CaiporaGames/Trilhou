using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public float forca = 500f;
    public Rigidbody2D coco;
    public bool liberarPulo = false;
    public int duplo = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (duplo > 0)
        {
            if ( Input.GetKeyDown(KeyCode.Space))
            {
                //Input.GetKeyDown(KeyCode.Space)
                coco.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
                duplo--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moldura"))
        {
            duplo = 2;
            liberarPulo = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moldura"))
        {
            liberarPulo = false;
        }
    }
}
