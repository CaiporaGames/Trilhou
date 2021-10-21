using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Timoteo {
    public class BlackboardManager : MonoBehaviour
    {
        [SerializeField] GameObject nextSceneBtn;
        [SerializeField] FadeTransition fadeTransition;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ShowBtn());
        }

        IEnumerator ShowBtn()
        {
            yield return new WaitForSecondsRealtime(5);
            nextSceneBtn.SetActive(true);
        }

        public void NextScene()
        {
            fadeTransition.CloseTransition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}