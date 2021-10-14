using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Books : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private string color;
    
    public void SetColor(string color){
        this.color = color;

        if (color == "white") {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (color == "red")
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if(color == "blue")
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(color == "yellow")
        {
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if(color == "black")
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else if (color == "green")
        {
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

    }

    public string GetColor() {
        return this.color;
    }
    public void Collided() {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 2);
    }
}
