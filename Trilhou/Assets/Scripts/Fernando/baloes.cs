using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Fernando
{
    public class baloes : MonoBehaviour
    {
        private Rigidbody BalaoRig;
        public int Speed;

        // Start is called before the first frame update
        void Start()
        {
            BalaoRig = GetComponent<Rigidbody>();

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                BalaoRig.AddForce(transform.forward * Speed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                BalaoRig.AddForce(transform.forward * -Speed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.A))
            {
                BalaoRig.AddForce(transform.forward * Speed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.D))
            {
                BalaoRig.AddForce(transform.forward * Speed * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }
}