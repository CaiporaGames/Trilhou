using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Timoteo
{
    //Para funcionar este script tem que estar em um gameobject no canvas. Este mesmo gameobject tem que ter um collider, este collider
    //pode estar como trigger ou não. Na hieraquia tem que ter um EventSystem component.
    public class TestScene : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        [SerializeField] float xDistance;
        [SerializeField] float yDistance;
        [SerializeField] float verticalVelocity;
        [SerializeField] float horizontalVelocity;

        bool isHolding = false;


        public void OnPointerDown(PointerEventData eventData)
        {
            LeanTween.pause(gameObject);
            isHolding = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            LeanTween.resume(gameObject);
            isHolding = false;

        }

        // Start is called before the first frame update
        void Start()
        {
            LeanTween.moveY(gameObject.GetComponent<RectTransform>(), yDistance, verticalVelocity).setLoopPingPong();
            LeanTween.moveX(gameObject.GetComponent<RectTransform>(), xDistance, horizontalVelocity).setLoopPingPong();
        }

        // Update is called once per frame
        void Update()
        {
            if (isHolding)
            {
                gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
            }
        }
    }

}