using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class FourthLevelDialogue : MonoBehaviour//, ICameraController
    {
        int dialogueIndex;

        public void Camera2DMovement(Transform startPoint, Transform endPoint, int index, Camera A, Camera B, float time, float zoom, bool zoomOut = false)
        {
            if (index == dialogueIndex)
            {
                B.gameObject.SetActive(false);
                A.gameObject.SetActive(true);

                LeanTween.move(A.gameObject, startPoint, 0);
                LeanTween.move(A.gameObject, endPoint, time);

                A.GetComponent<Camera>().orthographicSize = zoom;

                if (zoomOut)
                {
                    StartCoroutine(ZoomOut(A, zoom, time));
                }
                else
                {
                    StartCoroutine(ZoomIn(A, zoom, time));
                }

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
                A.gameObject.GetComponent<Camera>().orthographicSize
                    -= Time.deltaTime / time;
            }
        }
    }
}