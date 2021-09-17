using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balao : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colidiu...");
            gameObject.SetActive(false);
            LevelManagerBalloon.levelManager.SetBaloes();
        }
    }
}
