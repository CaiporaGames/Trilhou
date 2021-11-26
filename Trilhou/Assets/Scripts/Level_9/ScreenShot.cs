using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenShot : MonoBehaviour
{

    public void TakePhoto()
    {
        StartCoroutine(ScreensShot());
    }
   IEnumerator ScreensShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0,Screen.width, Screen.height), 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        string name = "Certificado_Pesquisador_Nivel_1" + System.DateTime.Now.ToString() +".png";
        File.WriteAllBytes(Application.dataPath + name, bytes);

        Destroy(texture);       
    }
}
