using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

namespace Timoteo
{
    public class DragCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] SOBalloonOptions options;
        [SerializeField] GameObject[] hearts;
        [SerializeField] GameObject panel;
        [SerializeField] SOGeneralVariables generalVariables;

        bool canDrag = false;
        TextMeshProUGUI cardText;
        TextMeshProUGUI otherCardText;
        bool runOnce = true;
       

        Vector3 startPos;
      

        private void Start()
        {
            cardText = GetComponentInChildren<TextMeshProUGUI>();
            startPos = transform.position;

        }

        private void Update()
        {
            if (canDrag)
            {
                transform.position = Input.mousePosition;
            }          
        }

        

        public void OnPointerDown(PointerEventData eventData)
        {
            canDrag = true;
            runOnce = true;
            LeanTween.scale(gameObject, new Vector3(1f, 0.5f, 1), 0.5f);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canDrag = false;
            LeanTween.scale(gameObject, new Vector3(2f, 1f, 1), 0.5f);

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (!canDrag && runOnce)
            {
                runOnce = false;
                otherCardText = collision.GetComponentInChildren<TextMeshProUGUI>();

                if (cardText.text == otherCardText.text)
                {
                    options.RemoveFromList(cardText.text);
                    panel.SetActive(false);
                    generalVariables.gamePaused = false;
                }
                else
                {
                    generalVariables.gamePaused = false;
                    generalVariables.playerHearts--;
                    hearts[generalVariables.playerHearts].gameObject.GetComponent<LTBalloonEffect>().StartEffect();
                    panel.SetActive(false);

                }

            }
        }

        private void OnDisable()
        {
            transform.position = startPos;
        }
    }
}
