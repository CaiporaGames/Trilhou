using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMessageManager : MonoBehaviour
{
    [SerializeField] GameObject messagerPanel;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void CloseMessage()
    {
        messagerPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenMessage()
    {
        messagerPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
