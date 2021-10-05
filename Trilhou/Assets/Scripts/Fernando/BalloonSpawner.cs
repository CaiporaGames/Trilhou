using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    [SerializeField] GameObject balloon;
    [SerializeField] float maxTimeBetweenBalloons;
    [SerializeField] SOGeneralVariables variables;

    float timeBetweenBalloons;


    private void Start()
    {
        timeBetweenBalloons = maxTimeBetweenBalloons;
        SpawnObjects();
    }

    private void Update()
    {
        timeBetweenBalloons -= Time.deltaTime;
        if (!variables.gamePaused)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        if (timeBetweenBalloons <= 0)
        {
            timeBetweenBalloons = maxTimeBetweenBalloons;

            for (int i = 0; i < points.Length; i++)
            {
                Instantiate(balloon, points[i].transform.position, Quaternion.identity);
            }
        }
    }

    public void UnpauseGame()
    {
        variables.gamePaused = true;
    }
}
