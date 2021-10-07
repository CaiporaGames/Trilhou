using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Paulo
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private bool hasBook;
        private GameObject book;
        private GameObject studyGroup;
        private bool isPlaying;
        private string request;
        private bool activeRequest;
        private bool timeOutCollision;

        private void Start()
        {
            this.isPlaying = false;
            this.hasBook = false;
            this.timeOutCollision = false;
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Obstruction" && isPlaying && !timeOutCollision)
            {
                this.gameObject.SendMessageUpwards("WrongCollision");
                timeOutCollision = true;
                Invoke("TimeOutCollision",2);
            }

            if (collision.gameObject.tag == "Shelf" && !hasBook && isPlaying)
            {
                string colorShelf = collision.gameObject.GetComponent<ShelfsManager>().GetColor();

                if (request == colorShelf && activeRequest)
                {
                    book = collision.transform.parent.transform.GetChild(1).gameObject;
                    book.transform.position = transform.position;
                    book.transform.SetParent(transform);
                    hasBook = true;
                    gameObject.SendMessageUpwards("TookBook", studyGroup);
                }
                else
                {
                    if (!timeOutCollision) {
                        this.gameObject.SendMessageUpwards("WrongCollision");
                        timeOutCollision = true;
                        Invoke("TimeOutCollision", 2);
                    }
                }
            }
            if (collision.gameObject.tag == "StudyGroup" && isPlaying)
            {
                if (hasBook)
                {
                    string item = book.GetComponent<Books>().GetColor();

                    if (item == request)
                    {
                        //gera dialogo com o grupo 
                    }
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

            if (collision.gameObject.tag == "StudyGroup" && isPlaying)
            {
                if (hasBook)
                {
                    string item = book.GetComponent<Books>().GetColor();

                    if (item == request)
                    {
                        transform.GetChild(0).SendMessage("Collided");
                        hasBook = false;
                        activeRequest = false;
                        gameObject.SendMessageUpwards("RightCollision");
                    }
                    else
                    {
                        this.gameObject.SendMessageUpwards("WrongCollision");
                    }
                }
                else if (!activeRequest)
                {
                    //pausa o tempo e exibe dialogo
                    studyGroup = collision.gameObject;
                    request = studyGroup.GetComponent<StudyGroup>().GetRequest();
                    if (request != null) {
                        gameObject.SendMessageUpwards("TookRequest", request);
                        activeRequest = true;
                    }
                }
            }
        }
        private void TimeOutCollision() {
            timeOutCollision = false;
        }
        public void DestroyBook() {
            //destroi o livro e zera variaveis
        }
        public bool GetHasBook()
        {
            return this.hasBook;
        }
        public void StopPlaying()
        {
            if (hasBook) {
                transform.GetChild(0).SendMessage("Collided");
                hasBook = false;
            }
            isPlaying = false;
            activeRequest = false;
        }

    }
}
