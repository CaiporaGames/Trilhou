using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    static ScreenShot _instance;
    [SerializeField] SONameHolder studentName;
    public static ScreenShot Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != this && _instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public string TakePhoto()
    {
        StartCoroutine(ScreensShot());
        return Application.persistentDataPath;
    }
   IEnumerator ScreensShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0,Screen.width, Screen.height), 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        string name = "Certificado_Pesquisador_Nivel_1_" + studentName.studentName+ "_" + Random.value +".png";
        File.WriteAllBytes(Application.persistentDataPath + name, bytes);
        Debug.Log(Application.persistentDataPath + name);
        Destroy(texture);       
    }
}
