using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timoteo {
    public class CinemachineManager : MonoBehaviour
    {
        byte setenceIndex;//This index is the same as the dialogue but it cannot came back
        ICameraController cameraController;


        private void OnEnable()
        {
            DialogueManager.NextDialogueDelegate += VerifyIndex;
        }

        private void Start()
        {
            setenceIndex = DialogueManager.Instance.SentenceIndex;
            cameraController = GetComponent<ICameraController>();
            CameraController();
        }

        void CameraController()
        {
            cameraController.Controller(setenceIndex);
        }

  
        void VerifyIndex()//This is called to increase the setenceIndex. It must just go futher for the cameras animations
        {
            if (DialogueManager.Instance.SentenceIndex > setenceIndex)
            {
                setenceIndex++;
                CameraController();
            }
        }

        private void OnDisable()
        {
            DialogueManager.NextDialogueDelegate -= VerifyIndex;
        }

    }
}