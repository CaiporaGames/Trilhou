using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvents : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Debug.Log("Entrou!");
    }

    private void OnMouseExit()
    {
        Debug.Log("Saiu!");
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicou!");
    }
}
