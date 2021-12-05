using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    [SerializeField] SOBoolean canPlayAudio;
   
    // Start is called before the first frame update
    void Update()
    {
        if (canPlayAudio.boolean)
        {
            gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 0.3f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);

        }
        
       
    }  
}
