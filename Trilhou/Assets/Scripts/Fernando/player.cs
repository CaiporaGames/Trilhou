using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fernando
{

    public class player : MonoBehaviour
    {

        pai p;
        filho f;


        // Start is called before the first frame update
        void Start()
        {
            p = new pai();
            print(p.idade);
            f = new filho();
            f.pegarIdade();

        }

        // Update is called once per frame
        void Update()
        {

        }


    }

    class pai : MonoBehaviour
    {
        public int idade = 48;

    }

    class filho : pai
    {
        public void pegarIdade()
        {
            print(base.idade);
        }
    }
}