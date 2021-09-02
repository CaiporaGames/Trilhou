using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coco : MonoBehaviour
{
    public float forca = 200f;
    public Rigidbody2D coco;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.CompareTag("Coco"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coco.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
        
        
    }
}
