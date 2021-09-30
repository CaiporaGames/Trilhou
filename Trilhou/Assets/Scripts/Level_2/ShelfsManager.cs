using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelfsManager : MonoBehaviour
{
    private string color;

    [SerializeField]
    private TMP_Text secao;
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(string color)
    {
        this.color = color;
        this.secao.text = color;
    }

    public string GetColor()
    {
        return this.color;
    }


}
