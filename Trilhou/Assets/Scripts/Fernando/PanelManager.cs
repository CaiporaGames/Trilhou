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

    public void PutNameOnCards(string name)
    {
        panel.SetActive(true);
        int i = Random.Range(0, cards.Length);
        cards[i].text = name;
        card.text = name;
        variables.gamePaused = true;
    }

    void TextCounter()
    {
        textCount.text = "Faltam: " + options.ballonOptions.Count.ToString();
    }
   
}
