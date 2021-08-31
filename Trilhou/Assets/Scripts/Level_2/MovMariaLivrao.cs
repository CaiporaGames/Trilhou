using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMariaLivrao : MonoBehaviour
{
    private Animator animator;
    [SerializeField] 
    private float speed = 10f;
    private bool hasBook;
    private int score;

    private void Start()
    {   
        this.animator = this.GetComponent<Animator>();
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
        
        if (collision.gameObject.name == "Bancada" && !hasBook) {
            this.gameObject.SendMessageUpwards("StartPlaying");
            GameObject book = collision.gameObject.transform.GetChild(0).gameObject;

            book.transform.position = this.transform.position;
            book.transform.SetParent(transform);
            this.hasBook = true;
        }

        //Se colidir com uma estante e tiver um livro em mãos, o livro é destruido
        //e a pontuação incrementada.
        if (collision.gameObject.tag == "Shelf" && this.hasBook)
        {
            this.transform.GetChild(0).SendMessage("Colidiu");
            this.hasBook = false;
            this.score += 1;
            this.gameObject.SendMessageUpwards("incrementCounter", this.score);
        }
    }
    public bool GetHasBook() {
        return this.hasBook;
    }

}
