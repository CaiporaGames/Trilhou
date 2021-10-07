using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Paulo {
    public class StudyGroup : MonoBehaviour
    {
        private bool isPlaying;
        private List<string> colors;
        private string request;
        private bool activeRequest;
        private int indice;

        [SerializeField] private float spawnRequestDelay;
        [SerializeField] private GameObject popUpRequest;
        [SerializeField] private Animator animator;
        [SerializeField] private TMP_Text popUpText;
        [SerializeField] private List<string> Questions;

        System.Random random = new System.Random();

        private void Start()
        {
            indice = Questions.Count;
            isPlaying = false;
            popUpRequest.SetActive(false);
        }

        public string GetRequest()
        {
            activeRequest = false;
            return request;
        }

        public void StartPlaying(List<string> colors)
        {
            this.colors = colors;
            Invoke("NewRequest", spawnRequestDelay);
            isPlaying = true;
        }
        public void StopPlaying()
        {
            isPlaying = false;
            //detroi todos requests ativos
        }

        public void NewRequest()
        {
            //Instantiate(spawnee, transform.position, transform.rotation);

            if (!isPlaying)
            {
                CancelInvoke("NewRequest");
            }
            else if (!activeRequest)
            {
                int index = random.Next(colors.Count);
                string color = colors[index];
                request = color;
                activeRequest = true;
                PopUp();
                popUpRequest.SetActive(true);
            }
        }

        public void PopUp()
        {
            indice -= 1;
            popUpRequest.SetActive(true);
            popUpText.text = Questions[indice];
            //animator.SetTrigger("pop");
        }
    }

}