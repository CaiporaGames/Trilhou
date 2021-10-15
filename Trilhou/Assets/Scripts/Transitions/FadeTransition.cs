using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timoteo
{
    public class FadeTransition : MonoBehaviour, ITransition
    {
        [SerializeField] float time;
        [SerializeField] RectTransform logo;

        CanvasGroup canvasGroup;
        private void Awake()
        {
            DialogueManager.lastDialogueIndex += CloseTransition;
            canvasGroup = GetComponent<CanvasGroup>();
            ResetScales();
            OpenTransition();
        }
        public void CloseTransition()
        {
            StartCoroutine(FadeIn());
        }

        public void OpenTransition()
        {
            StartCoroutine(FadeOut());
        }

        void ResetScales()
        {
            canvasGroup.alpha = 1;
            logo.localScale = new Vector3(14, 14, 14);
        }

        IEnumerator FadeOut()
        {
            while (canvasGroup.alpha > 0.001f)
            {
                yield return null;
                canvasGroup.alpha -= Time.unscaledDeltaTime / time;

                ScaleDown(canvasGroup.alpha);
            }
        }

        IEnumerator FadeIn()
        {
            while (canvasGroup.alpha < 1)
            {
                yield return null;
                canvasGroup.alpha += Time.unscaledDeltaTime / time;
                ScaleUp(canvasGroup.alpha);

            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        void ScaleDown(float t)
        {
            logo.localScale -= new Vector3(t, t, t);
        }

        void ScaleUp(float t)
        {
            if (logo.localScale.x >= 14)
            {
                return;
            }
            logo.localScale += new Vector3(t, t, t);
        }

        private void OnDisable()
        {
            DialogueManager.lastDialogueIndex -= CloseTransition;

        }
    }
}