using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace Timoteo
{
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] points;
        [SerializeField] GameObject balloon;
        [SerializeField] float maxTimeBetweenBalloons;
        [SerializeField] SOGeneralVariables variables;
        [SerializeField] SOBalloonOptions options;
        [SerializeField] GameObject messagePanel;

        float timeBetweenBalloons;


        private void Start()
        {
            timeBetweenBalloons = maxTimeBetweenBalloons;
            SpawnObjects();
            options.AddWordsToBallonOptions();
        }

        private void Update()
        {
            timeBetweenBalloons -= Time.deltaTime;
            if (!variables.gamePaused)
            {
                SpawnObjects();
            }
            if (options.ballonsCounter == 0)
            {
                PointsBar.Instance.AddPointsToBar();
            }
            if (variables.playerHearts <= 0)
            {
                messagePanel.SetActive(true);
                messagePanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text =
                    "Oh, você não acertou. Não desista, tente novamente!";
                StartCoroutine(NextScene());
            }
        }

        IEnumerator NextScene()
        {
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}