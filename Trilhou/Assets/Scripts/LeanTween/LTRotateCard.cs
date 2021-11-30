using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LTRotateCard : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] SOInteger cardsCount;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        cardsCount.value++;
        if (cardsCount.value == 7)
        {
            StartCoroutine(NextScene());
        }
        LeanTween.rotateY(gameObject, 180, 2);
        audioSource.Play();
    }  

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
