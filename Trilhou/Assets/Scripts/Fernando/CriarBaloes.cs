using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarBaloes : MonoBehaviour
{
    public GameObject baloes;
    public GameObject bocaBarril;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(baloes, new Vector3(bocaBarril.transform.position.x, bocaBarril.transform.position.y, bocaBarril.transform.position.z), Quaternion.identity);
            print("balao criado em " + baloes.transform.position.x + baloes.transform.position.y + baloes.transform.position.z);
        }
        
    }
}
