using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelManager : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI[] cards;                           
    [SerializeField] TextMeshProUGUI card;
    [SerializeField] SOGeneralVariables variables;
    [SerializeField] TextMeshProUGUI textCount;
    [SerializeField] SOBalloonOptions options;


    string[] words = new string[10]
    {"Casa?", "Jogar?", "Televisão?", "Lua?", "Peixe?", "Dez?", "Desenho?", "Amarelo?", "Quadrado?", "Escola?" };

    public static PanelManager _instance;
    public static PanelManager Instance { get { return _instance; }}   

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }else
        {
            _instance = this;
        }
    }

    private void Update()
    {
        TextCounter();
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

    void TextCounter()
    {
        textCount.text = "Faltam: " + options.ballonOptions.Count.ToString();
    }
   
}
