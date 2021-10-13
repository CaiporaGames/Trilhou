using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CodeManager : MonoBehaviour
{

    [SerializeField] TMP_InputField codeInput;
    [SerializeField] GameObject errorMessage;
    [SerializeField] SOCode codes;

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        errorMessage.SetActive(false);
        text = errorMessage.GetComponent<TextMeshProUGUI>();
    }

    public void CodeButton()
    {
        CodeComparator codeComparator = new CodeComparator(codeInput.text, codes.codes, codes.levelIndex);

        if (!codeComparator.CompareCode())
        {
            errorMessage.SetActive(true);
            text.text = codeComparator.Message("O código esta errado!");
            StartCoroutine(CloseErrorMessage());
        }
        else
        {
            codes.levelIndex++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }      

    }

    IEnumerator CloseErrorMessage()
    {
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
    }
}
