using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Paulo
{
    public class PopUpRequest : MonoBehaviour
    {
        [SerializeField] GameObject popUpBox;
        [SerializeField] Animator animator;
        [SerializeField] TMP_Text popUpText;
        // Start is called before the first frame update

        public void PopUp(string text)
        {
            popUpBox.SetActive(true);
            popUpText.text = text;
            //animator.SetTrigger("pop");
        }
    }
}
