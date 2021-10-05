using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LTBalloon : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] float xtime;
    [SerializeField] float yPosition;


    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        ChooseColor();
        ChooseSize();
    }
    void Start()
    {
        int delay = Random.Range(0,4);
        int randomX = Random.Range(-5, 6);
        float ytime = Random.Range(4, 7);
        LeanTween.moveY(gameObject, yPosition, ytime).setEase(curve).setDelay(delay);
        LeanTween.moveX(gameObject, randomX, xtime).setEase(curve).setLoopPingPong();
    }

    void ChooseColor()
    {
        int i = Random.Range(0, 7);

        switch (i)
        {
            case 1:
                sprite.material.color = Color.red;
                break;
            case 2:
                sprite.material.color = Color.green;
                break;
            case 3:
                sprite.material.color = Color.blue;
                break;
            case 4:
                sprite.material.color = Color.yellow;
                break;           
            case 5:
                sprite.material.color = Color.white;
                break;
            case 6:
                sprite.material.color = Color.cyan;
                break;
            default:
                sprite.material.color = Color.cyan;
                break;
        }
    }

    void ChooseSize()
    {
        int i = Random.Range(0,5);
        switch (i)
        {
            case 1:
                transform.GetChild(0).localScale = new Vector3(0.2f, 0.2f, 1);
                break;
            case 2:
                transform.GetChild(0).localScale = new Vector3(0.2f, 0.3f, 1);
                break;
            case 3:
                transform.GetChild(0).localScale = new Vector3(0.3f, 0.2f, 1);
                break;
            case 4:
                transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f, 1);
                break;
            default:
                transform.GetChild(0).localScale = new Vector3(0.2f, 0.2f, 1);
                break;
        }
    }
   
   
}
