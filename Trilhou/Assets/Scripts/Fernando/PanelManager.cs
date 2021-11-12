using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Timoteo
{
    public class PanelManager : MonoBehaviour
    {

        [SerializeField] GameObject panel;
        [SerializeField] TextMeshProUGUI[] cards;
        [SerializeField] TextMeshProUGUI card;
        [SerializeField] SOGeneralVariables variables;
        [SerializeField] SOBalloonOptions options;
        [SerializeField] Image[] stars = new Image[11];

        AudioSource audioSource;

        string[] words = new string[4]
        {"Não gostei do assunto!", "Não foi isso que o professor pediu!", "Não vou conseguir organizar essas informações!", "Estou tão confusa!"};

        public static PanelManager _instance;
        public static PanelManager Instance { get { return _instance; } }

        private void OnEnable()
        {
            DragCard.showStar += StarCount;
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }


        public void PutNameOnChoosedCard(string name)
        {
            panel.SetActive(true);
            int i = Random.Range(0, cards.Length);
            PutNameOnOthersCards(i);
            cards[i].text = name;
            card.text = name;
        }

        void PutNameOnOthersCards(int j)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (j != i)
                {
                    cards[i].text = words[i];
                }
            }
        }

        void StarCount()
        {
            Image star = stars[11 - options.ballonOptions.Count - 1];
            star.color = new Color(1, 1, 0, 1);
            LeanTween.scale(star.gameObject, new Vector3(1.01f,1.01f,1), 0.5f).setEasePunch();
            audioSource.Play();
            // textCount.text = "Faltam: " + options.ballonOptions.Count.ToString();
        }

        private void OnDisable()
        {
            DragCard.showStar -= StarCount;
        }

    }
}
