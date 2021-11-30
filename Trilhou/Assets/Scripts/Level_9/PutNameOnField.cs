using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutNameOnField : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI path;
    [SerializeField] SONameHolder playerName;
    [SerializeField] GameObject photoInfoPanel;

    private void Start()
    {
        text.text = playerName.studentName;
        path.text = ScreenShot.Instance.TakePhoto();

        StartCoroutine(Panel());
    }

    IEnumerator Panel()
    {
        yield return new WaitForSeconds(1);
        photoInfoPanel.SetActive(true);
    }
}
