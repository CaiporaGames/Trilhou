using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Paulo
{
    public class BooksGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject book;

        public void CreateBook(string color)
        {
            GameObject livro = Instantiate(book, transform.position, Quaternion.identity);
            livro.transform.SetParent(transform.parent.transform);
            livro.SendMessage("SetColor", color);
        }
    }
}