using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{

    bool isPause;

    private void Pause()
    {
        Time.timeScale = 0;        
    }

    private void UnPause()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            if (isPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
        
    }
}
