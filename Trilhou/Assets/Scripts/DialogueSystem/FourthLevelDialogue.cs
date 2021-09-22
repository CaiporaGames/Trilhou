using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class FourthLevelDialogue : MonoBehaviour, ICameraController
    {
        [SerializeField] Camera[] _cameras;
        [Tooltip("How long takes to camera size returns to normal")]
        [SerializeField] Vector3[] positions;
        [SerializeField] float timer = 15;


        public void Controller(byte index)//cameras[0] scene 1.
        {

            if (index < 3)
            {
                _cameras[0].gameObject.SetActive(false);
                _cameras[1].gameObject.SetActive(true);

                _cameras[1].gameObject.GetComponent<Camera>().orthographicSize = 2;
                LeanTween.move(_cameras[1].gameObject, positions[0], 0);              
                LeanTween.move(_cameras[1].gameObject, positions[1], 15);
                StartCoroutine(ZoomOut(1));

            }
            else if (index < 5)
            {
                StopCoroutine(ZoomOut(1));
                _cameras[1].gameObject.SetActive(false);
                _cameras[0].gameObject.SetActive(true);

                _cameras[0].gameObject.GetComponent<Camera>().orthographicSize = 2;
                LeanTween.move(_cameras[0].gameObject, positions[2], 0);
                LeanTween.move(_cameras[0].gameObject, positions[3], 15);
                StartCoroutine(ZoomOut(0));
            }
        }     
        
        IEnumerator ZoomOut(int cameraIndex)
        {
            while (_cameras[cameraIndex].gameObject.GetComponent<Camera>().orthographicSize <= 5)
            {
                yield return null;
                _cameras[cameraIndex].gameObject.GetComponent<Camera>().orthographicSize
                    += Time.deltaTime / timer;

            }           
        }

        IEnumerator ZoomIn()
        {

            while (_cameras[1].gameObject.GetComponent<Camera>().orthographicSize >= 2)
            {
                yield return null;
                _cameras[1].gameObject.GetComponent<Camera>().orthographicSize
                    -= Time.deltaTime / timer;
            }
        }
    }
}