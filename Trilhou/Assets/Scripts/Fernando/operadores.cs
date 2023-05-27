using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fernando
{
    public class operadores : MonoBehaviour
    {
        // Start is called before the first frame update
        int num1, num2, num3, resultado;

        void Start()
        {
            num1 = 10;
            num2 = 2;
            num3 = 5;
            resultado = num1++ + num2++ * num3--;
        }

        // Update is called once per frame
        void Update()
        {
            //resultado = num1++ + num2++ + num3--;
            print(resultado);
        }
    }
}