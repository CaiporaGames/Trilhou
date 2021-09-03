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
    }

    public string GetColor() {
        return this.color;
    }
    public void Colidiu() {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 2);
    }
}
