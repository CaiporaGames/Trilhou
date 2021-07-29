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
       // Vector2 direction = points[oldIndice].gameObject.transform.position - points[oldIndice - 1].gameObject.transform.position;
       // float angle = Vector2.SignedAngle(direction, transform.GetChild(0).transform.position);

       // transform.GetChild(0).transform.Rotate(new Vector3(0, 0, angle));
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
       // Vector2 direction = points[oldIndice].gameObject.transform.position - points[oldIndice - 1].gameObject.transform.position;
       // float angle = Vector2.SignedAngle(direction , transform.GetChild(0).transform.position);

       // transform.GetChild(0).transform.Rotate(new Vector3(0, 0, angle));
    }
}
