using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Timoteo
{
    //this is on the antspawner on the gamescene. It controls the the ants timer to spawn...
    public class AntSpawner : MonoBehaviour
    {
        [SerializeField] Transform spawnerPosition;
        [SerializeField] GameObject antPrefab;
        [SerializeField] float maxTimeRate; //controls the rate between two ants spawn
        [SerializeField] List<GameObject> points = new List<GameObject>();

        float timeRate;


        // Update is called once per frame
        void Update()
        {
            timeRate -= Time.deltaTime;

            if (timeRate <= 0)
            {
                timeRate = maxTimeRate;
                GameObject ant = Instantiate(antPrefab, spawnerPosition.position, Quaternion.identity);
                ant.GetComponent<AntControllerPath>().GetPoints(points);
            }
        }
    }
}