using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fernando
{
    public class Carta : MonoBehaviour
    {
        // Start is called before the first frame update
        public Color cor;

        void Start()
        {
            gameObject.GetComponent<MeshRenderer>().material.color = cor;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}