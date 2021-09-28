using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingMessageManager : MonoBehaviour
{
    [SerializeField] GameObject messagerPanel;

   
    public void CloseMessage()
    {
        messagerPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
