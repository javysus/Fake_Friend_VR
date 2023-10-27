using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class CamiControllerLaying : MonoBehaviour
    {
        public GameObject puerta;

        public GameObject toilet;

        public GameObject caminoLuz;

        public GameObject OscarControlador;

        public DSDialogue dialogo_alcohol;
        public DSDialogue dialogo_bebida;

        private int decision = 0; //0 es tomar alcohol
        private bool dialogo1 = true;

        public AudioSource sonidoEstomacal;
        public AudioSource dolorCabeza;

        //Historia

        //Efectos resaca
        private bool efectosUno = true;

        //Reto del hermano
        private bool visitaHermano = false;

        //Ducha
        public bool ducharse = false;
        public BoxCollider colliderDucha;
        // Start is called before the first frame update
        void Start()
        {
            dolorCabeza.Play();
            sonidoEstomacal.Play();
        }

        // Update is called once per frame
        void Update()
        {
            //El dialogo comienza cuando la puerta tenga una rotacion mayor a 75

            float rotation = puerta.transform.rotation.z;
            //Debug.Log(rotation);
            if (rotation < 0.16 && decision==0 && dialogo1)
            {
                Debug.Log("La puerta se ha abierto");
                dialogo_alcohol.StartDialogue("Oscar");
                dialogo1 = false;
            }

            if (!dolorCabeza.isPlaying && !sonidoEstomacal.isPlaying && decision==0 && efectosUno)
            {
                Debug.Log("DEBUG Historia vomito");
                //Activar el water para ir a vomitar
                toilet.GetComponent<BoxCollider>().enabled = true;
                toilet.GetComponent<Vomitar>().enabled = true;
                caminoLuz.SetActive(true);

                //Activar camino de luz
                caminoLuz.GetComponent<Animator>().SetTrigger("Toilet");

                //Se termina esta parte de la historia
                efectosUno = false;
                visitaHermano = true;
            }

            if (visitaHermano)
            {
                //Activar controlador del hermano
                visitaHermano = false;
                OscarControlador.SetActive(true);
            }

            if (ducharse)
            {
                caminoLuz.SetActive(true);
                caminoLuz.GetComponent<Animator>().ResetTrigger("Toilet");
                caminoLuz.GetComponent<Animator>().SetTrigger("Ducha");
                Debug.Log("Activo la duchita");
                //Activar collider de ducha y boton
                colliderDucha.enabled = true;
                ducharse = false;
            }
        }
    }
}