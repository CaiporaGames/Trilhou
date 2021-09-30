using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMariaLivrao : MonoBehaviour
{
    private Animator animator;
    private GameObject book;

    [SerializeField] 
    private float speed = 10f;
    private bool hasBook;
    private bool isPlaying;
    private int score;
 

    private void Start()
    {   
        this.animator = this.GetComponent<Animator>();
        this.isPlaying = false;
        this.hasBook = false;
        this.score = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float forcax = x* Time.deltaTime * speed;
        float forcay = y * Time.deltaTime * speed;

        Vector2 movement = new Vector2(forcax, forcay);

        this.transform.Translate(movement);
        bool andando = movement.magnitude != 0;


        this.animator.SetBool("isWalking", andando);
        this.animator.SetFloat("Horizontal", movement.x);
        this.animator.SetFloat("Vertical", movement.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   

        if (collision.gameObject.name == "Bancada" && !hasBook && this.isPlaying) {
            book = collision.gameObject.transform.GetChild(0).gameObject;
            book.transform.position = this.transform.position;
            book.transform.SetParent(this.transform);
            this.hasBook = true;
            this.gameObject.SendMessageUpwards("SetGuide", book);
        }

        //Se colidir com uma estante e tiver um livro em mãos, o livro é destruido
        //e a pontuação incrementada.
        if (collision.gameObject.tag == "Shelf" && this.hasBook)
        {   
            string colorShelf = collision.gameObject.GetComponent<ShelfsManager>().GetColor();
            string colorBook = this.book.GetComponent<Books>().GetColor();

            if (colorBook == colorShelf) {
                this.transform.GetChild(0).SendMessage("Colidiu");
                this.hasBook = false;
                this.score += 1;
                this.gameObject.SendMessageUpwards("IncrementCounter", this.score);
                this.gameObject.SendMessageUpwards("RightCollision");
            }
            else {
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

    public bool GetisPlaying()
    {
        return this.isPlaying;
    }

}
