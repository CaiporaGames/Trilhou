using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class CameraMovement : MonoBehaviour, ICameraController//This is to make camera movement on the talk scene.
    {
        public List<Positions> Positions = new List<Positions>();

        byte dialogueIndex = 0;//This is the count to go to next movement.

        public void Camera2DMovement(byte index)
        {
            if (index == Positions[dialogueIndex].index){

                    LeanTween.cancelAll();
                    Positions[dialogueIndex].B.gameObject.SetActive(false);
                    Positions[dialogueIndex].A.gameObject.SetActive(true);

                    LeanTween.move(Positions[dialogueIndex].A.gameObject, Positions[dialogueIndex].startPoint, 0);
                    LeanTween.move(Positions[dialogueIndex].A.gameObject, Positions[dialogueIndex].endPoint, Positions[dialogueIndex].time);

                    Positions[dialogueIndex].A.GetComponent<Camera>().orthographicSize = Positions[dialogueIndex].zoomBeggining;

                    if (Positions[dialogueIndex].zoomOut)
                    {
                        StartCoroutine(ZoomOut(Positions[dialogueIndex].A, Positions[dialogueIndex].zoomEnding, Positions[dialogueIndex].time));
                    }
                    else
                    {
                        StartCoroutine(ZoomIn(Positions[dialogueIndex].A, Positions[dialogueIndex].zoomEnding, Positions[dialogueIndex].time));
                    }
                
                dialogueIndex++;
            }
        }


        
        IEnumerator ZoomOut(Camera A, float zoom, float time)
        {
            while (A.gameObject.GetComponent<Camera>().orthographicSize <= zoom)
            {
                yield return null;
                A.gameObject.GetComponent<Camera>().orthographicSize
                    += Time.deltaTime / time;

            }           
        }

        IEnumerator ZoomIn(Camera A, float zoom, float time)
        {
            while (A.gameObject.GetComponent<Camera>().orthographicSize >= zoom)
            {
                yield return null;
                A.gameObject.GetComponent<Camera>().orthographicSize -= Time.deltaTime / time;
            }
        }
    }
}


[System.Serializable]
public class Positions
{
    [Tooltip("This is from the camera start movement")]
    public Transform startPoint;
    [Tooltip("This is where the camera ends movement")]
    public Transform endPoint;
    [Tooltip("This is the index where the camera need to play this movement")]
    public int index;
    [Tooltip("This is the camera that will be enabled for this movement")]
    public Camera A;
    [Tooltip("This is the camera that will be disabled for this movement")]
    public Camera B;
    [Tooltip("How long the camera takes from startPoint to endPoint")]
    public float time;
    [Range(2,5)]
    [Tooltip("What is the zoom of the camera in the begging? This is the camera size variable.")]//2 is to zoom out and 5 is for zoom in
    public float zoomBeggining;
    [Range(2, 5)]
    [Tooltip("What is the zoom of the camera in the ending? This is the camera size variable.")]//2 is to zoom out and 5 is for zoom in
    public float zoomEnding;
    [Tooltip("Is the camera zoom in or zoom out. if zoom out if market that will happens!")]
    public bool zoomOut;
}