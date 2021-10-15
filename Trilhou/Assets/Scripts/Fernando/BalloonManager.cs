using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Timoteo {
    public class BalloonManager : MonoBehaviour
    {
        [SerializeField] GameObject messageCanvas;
        [SerializeField] FadeTransition fadeTransition;

        private void OnEnable()
        {
            BalloonExplosion.balloonOptionIsEmpty += StartDominoEffect;
        }


        private void OnDisable()
        {
            BalloonExplosion.balloonOptionIsEmpty -= StartDominoEffect;
        }

        void StartDominoEffect()
        {
            RaiseWinPanel();
            StopTime();
            StartCoroutine(Transition());
        }

        void RaiseWinPanel()
        {
            messageCanvas.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "Parabéns, Você acertou todas!";
        }

        void StopTime()
        {
            Time.timeScale = 0;
        }

        IEnumerator Transition()
        {
            yield return new WaitForSeconds(4);
            fadeTransition.CloseTransition();
        }
    }
}
