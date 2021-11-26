using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] SONameHolder studentName;

    public void CodeButton()
    {
        studentName.studentName = inputField.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
