using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class Golpear : MonoBehaviour
    {
        public static bool esGolpe = false;
        public bool golpear = false;
        public GameObject Mojojojo;
        // Start is called before the first frame update
        void Start()
        {

        }
        /*private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BrazoLoca") && !esGolpe) //En realidad es la cabeza
            {
                esGolpe = true;
                Mojojojo.GetComponent<MojojojoController>().RecibirGolpe();
            }
        }*/

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Hubo colision");
            if(collision.gameObject.CompareTag("Mano"))
            {
                esGolpe = true;
                Mojojojo.GetComponent<MojojojoController>().RecibirGolpe();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}