using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is on the gameobjects that have renderer component. It calculates the sorting order on the objects so the player will appear in front, or behind, the rights elements 
public class RenderOrder : MonoBehaviour
{
    [SerializeField] int sortingOrder = 5000;
    [SerializeField] int offset = 0;//This is used to put the effect on the character feet. Probabile it is on the character middle.
    [SerializeField] bool runOnlyOnce = false;//The objects that are static on the game do not need to calculate the sorting order more then once.

    float timer;
    float timerMax = 0.1f;//THis make the update run less. It is good for performance.
    Renderer _renderer;

    // Start is called before the first frame update
    void Awake()
    {
        _renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = timerMax;
            _renderer.sortingOrder = (int)(sortingOrder - transform.position.y - offset);//This set the gameobject sorting order based on it y position.

            if (runOnlyOnce)
            { 

                Destroy(this);
            }
        }
    }
}
