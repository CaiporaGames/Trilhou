using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo
{
    
    public class AntControllerPath : MonoBehaviour
    {

        List<GameObject> points;
        [SerializeField] float antSpeed;
        Vector3 nextPosition;
        int oldIndice = 1;

        public void GetPoints(List<GameObject> points)//allows us to take the 
        {
            this.points = points;
            nextPosition = points[oldIndice].gameObject.transform.position;
         
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

            transform.position = Vector2.MoveTowards(transform.position, nextPosition, antSpeed * Time.deltaTime);

        }

        void NextPosition()//calculate what is the next point that the ants need to go
        {

            if (oldIndice == points.Count - 1)
            {
                Destroy(gameObject);
                return;
            }

            oldIndice += 1;


            nextPosition = points[oldIndice].gameObject.transform.position;           
        }
    }
}
