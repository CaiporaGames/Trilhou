using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // necessaria para realizar conversoes
namespace Fernando
{
    public class variaveis : MonoBehaviour
    {
        // Start is called before the first frame update
        int moedas;
        float dinheiro = 10.2f;
        bool divida = false;
        int carteira;
        string texto;
        // comentario de uma linha
        /*
         comentario de varias linhas
            usar geralmente em metodos
         */

        void Start()
        {
            moedas = 10 + (int)dinheiro;
            print(moedas);
            dinheiro = moedas + dinheiro;
            print(dinheiro);
            print(!divida);
            divida = !divida;
            carteira = Convert.ToInt32(divida) + (int)dinheiro;
            print(carteira);
            texto = carteira.ToString();
            print(texto);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}