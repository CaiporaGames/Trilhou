using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTBinoculoFollowPath : MonoBehaviour
{
    [Tooltip("This has all the position that the binoculo need to go")]
    [SerializeField] Transform[] nextPosition;
    [SerializeField] float time;
    [SerializeField] float delay;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {       
        LeanTween.move(gameObject, nextPosition[i++], time).setDelay(delay).setOnComplete(Start);
        if (i == nextPosition.Length)
        {
            Destroy(this);
        }
        if (i == 4)
        {
            delay = 0;
            time = time - 2;
        }
    }

}
