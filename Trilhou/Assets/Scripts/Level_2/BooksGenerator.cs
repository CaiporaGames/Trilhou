using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BooksGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject book;

    [SerializeField]
    private int generatedBooks;

    System.Random random = new System.Random();

    private string[] colors = new string[]{ "blue", "red", "yellow", "green", "black", "white" };

    // Start is called before the first frame update
    void Awake(){
        string color = RandomColor();
        GameObject livro = Instantiate(book, transform.position, Quaternion.identity);
        livro.SendMessage("SetColor", color);
        livro.transform.SetParent(this.transform);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {   
        //Cria referencia para o gameObject que colidiu
        GameObject collider = collision.gameObject;

        //Se foi a maria livrão que colidiu, então o livro atual é atribuido a maria
        //e um novo livro é gereado para substituir.
        if (collider.name == "MariaLivrao") {
            MovMariaLivrao mScript = collider.GetComponent<MovMariaLivrao>();
            if(mScript.GetHasBook()) {
                GameObject livro = Instantiate(book, transform.position, Quaternion.identity);
                string color = RandomColor();
                livro.transform.SetParent(this.transform);
                livro.SendMessage("SetColor", color);
            }
        }
    }

    private string RandomColor() {
        int index = random.Next(colors.Length);
        return colors[index];
    }
}
