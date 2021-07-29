using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntControllerPath : MonoBehaviour
{

    List<GameObject> points;
    [SerializeField] float antSpeed;
    Vector3 nextPosition;
    int oldIndice = 1;

    public void GetPoints(List<GameObject> points)
    {
        this.points = points;
        nextPosition = points[oldIndice].gameObject.transform.position;
        float angle = Mathf.Abs(Vector3.Angle(points[oldIndice].gameObject.transform.position, transform.position));
        transform.GetChild(0).gameObject.transform.Rotate(new Vector3(0, 0, -angle));

    }

    // Update is called once per frame
    void Update()
    {
        if (points == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, nextPosition) <= 0.5f)
        {

            NextPosition();
        }

       transform.position = Vector2.MoveTowards( transform.position , nextPosition , antSpeed * Time.deltaTime);
        
    }

    void NextPosition()
    { 

        if (oldIndice == points.Count-1)
        {
            Destroy(gameObject);
            return;
        }

        oldIndice += 1;
        nextPosition = points[oldIndice].gameObject.transform.position;
        //Vector2 direction = points[oldIndice + 1].gameObject.transform.position - points[oldIndice].gameObject.transform.position;
        // float angle = Vector2.SignedAngle(direction , points[oldIndice].gameObject.transform.position);      
        //transform.GetChild(0).gameObject.transform.Rotate(new Vector3(0, 0, angle));

        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, points[oldIndice].gameObject.transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, antSpeed * Time.deltaTime);
    }
}
