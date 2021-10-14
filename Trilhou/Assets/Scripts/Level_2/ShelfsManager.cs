using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Paulo
{
    public class ShelfsManager : MonoBehaviour
    {
        private string color;
        private bool isPlaying;
        private BooksGenerator booksGenerator;

        [SerializeField] private TMP_Text secao;

        void Start()
        {
            booksGenerator = gameObject.GetComponent<BooksGenerator>();
            isPlaying = false;
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

        public void CreateBook()
        {
            booksGenerator.CreateBook(color);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //Cria referencia para o gameObject que colidiu
            GameObject collider = collision.gameObject;

            //Se foi a maria livrão que colidiu, então o livro atual é atribuido a maria
            //e um novo livro é gereado para substituir.
            if (collider.tag == "Player")
            {
                PlayerManager mScript = collider.GetComponent<PlayerManager>();
                if (mScript.GetHasBook() && isPlaying)
                {
                    CreateBook();
                }
            }
        }
        private void StartPlaying()
        {
            isPlaying = true;
        }
        private void StopPlaying()
        {
            isPlaying = false;
        }
    }
}