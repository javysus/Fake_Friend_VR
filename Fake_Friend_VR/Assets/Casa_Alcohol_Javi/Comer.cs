using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class Comer : MonoBehaviour
    {
        // Start is called before the first frame update
        public AudioSource eating;
        private int haComido = 0; //Cuantos objetos se ha comido
        public GameObject dialogoNoComer;
        public float size = 0.001f;
        void Start()
        {

        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Comida"))
            {
                if (haComido < 3)
                {
                    Debug.Log("Entro el la comida");
                    other.gameObject.SetActive(false);
                    eating.Play();
                    haComido += 1;
                }

                else
                {
                    Debug.Log("TEST: No tiene mas hambre");
                    dialogoNoComer.LeanScale(new Vector3(size, size, size), 1f);

                    //Continuar dialogo
                    FindObjectOfType<DialogueManagerComedor>().DisplayMessage();
                    FindObjectOfType<DialogueManagerComedor>().isActive = true;
                }

            }
        }
    }
}
