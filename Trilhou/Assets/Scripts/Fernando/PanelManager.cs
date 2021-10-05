using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelManager : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI[] cards;                           
    [SerializeField] TextMeshProUGUI card;

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

    public void PutNameOnCards(string name)
    {
        panel.SetActive(true);
        int i = Random.Range(0, cards.Length);
        cards[i].text = name;
        card.text = name;
        Time.timeScale = 0;
    }
}
