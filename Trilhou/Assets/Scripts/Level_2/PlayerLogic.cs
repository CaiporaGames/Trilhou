using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private bool hasBook;
    private GameObject book;
    private bool isPlaying;

    private void Start()
    {
        this.isPlaying = false;
        this.hasBook = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Se o jogador colidir com a bancada de livros~, não possui livros como filho e está jogando
        //Então o livro é atribuido como filho e a seta guia é inicializada;
        if (collision.gameObject.name == "Bancada" && !hasBook && isPlaying)
        {
            book = collision.gameObject.transform.GetChild(0).gameObject;
            book.transform.position = transform.position;
            book.transform.SetParent(transform);
            hasBook = true;
            gameObject.SendMessageUpwards("TookBook", book);
        }

        //Se colidir com uma estante e tiver um livro em mãos, o livro é destruido
        //e a pontuação incrementada.
        if (collision.gameObject.tag == "Shelf" && this.hasBook && isPlaying)
        {
            string colorShelf = collision.gameObject.GetComponent<ShelfsManager>().GetColor();
            string colorBook = this.book.GetComponent<Books>().GetColor();

            if (colorBook == colorShelf)
            {
                this.transform.GetChild(0).SendMessage("Collided");
                this.hasBook = false;
                this.gameObject.SendMessageUpwards("IncrementCounter");
                this.gameObject.SendMessageUpwards("RightCollision");
            }
            else
            {
                this.gameObject.SendMessageUpwards("WrongCollision");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bibliotecaria" && !this.isPlaying)
        {
            //abre dialogo
            this.gameObject.SendMessageUpwards("StartPlaying");
            this.isPlaying = true;
        }
    }
    public bool GetHasBook()
    {
        return this.hasBook;
    }
    private void StopPlaying()
    {
        isPlaying = false;
    }

}
