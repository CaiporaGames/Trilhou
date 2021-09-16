using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.moveLocalX(gameObject, -2, 2 * Time.deltaTime);
        //LeanTween.moveLocalX(gameObject, 10, 20);
        LeanTween.moveLocalX(gameObject, -10, 30).setOnComplete(Log);

        //LeanTween.moveLocalY(gameObject, 2, 3);
        //LeanTween.moveLocalY(gameObject, 3, 3).setEase(curve);
        //LeanTween.moveLocalY(gameObject, 1, 2).setOnComplete(Log);
        //LeanTween.moveLocalY(gameObject, 5, 3).setLoopPingPong();
        //LeanTween.moveLocalY(gameObject, 1, 0.5f).setLoopPingPong();
        //LeanTween.move(gameObject, new Vector3(-2, 3, 0), 2).setLoopPingPong();
        
        //LeanTween.move(gameObject, new Vector3(1, 1, 0), 5).setEasePunch();
        //LeanTween.move(gameObject, new Vector3(1, 1, 0), 5).setEaseShake();
        //LeanTween.move(gameObject, new Vector3(3, 3, 0), 5).setEaseSpring();


    }
    void Update()
    {
        //LeanTween.moveLocalX(gameObject, -10, 20);
        Debug.Log("Movimento!");
    }

    void Log()
    {
        Debug.Log("Movimento iniciado!");
        //LeanTween.moveLocalY(gameObject, 1, 2).setOnComplete(UpX);
        UpX();
    }

    void UpX()
    {
        //LeanTween.moveLocalY(gameObject, 4, 10);
        //LeanTween.moveLocalX(gameObject, 10, 10).setOnComplete(DownX);
        LeanTween.move(gameObject, new Vector3(3, 3, 0), 2).setOnComplete(DownX);




    }
    void DownX()
    {
        //LeanTween.moveLocalY(gameObject, -4, 10);
        //LeanTween.moveLocalX(gameObject, -10, 10).setOnComplete(UpX);
        LeanTween.move(gameObject, new Vector3(-3, -3, 0), 2).setOnComplete(UpX);


    }
}
