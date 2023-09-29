using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class Contestar : MonoBehaviour
    {
        public Material Material1;
        public Material Material1_Mensaje;
        public Material Material2_Mensaje;
        public static Material Material3_Mensaje; //Respuesta
        public static Material Material4_Mensaje; //Respuesta
        public static Material Material5_Mensaje; //Mensaje
        public string[] logica = { "Respuesta", "Respuesta" , "Mensaje"};
        public string[] respuestas = { "Yo iguaaal, echo de menos el liceo", "Mas encima con el atao de mi papá, mi mamá no deja de hablar de eso" };

        public Material[] materiales = { Material3_Mensaje, Material4_Mensaje, Material5_Mensaje };

        public int posLogica = 0;
        public bool isActive = false;
        public AudioSource Llamada;
        public AudioSource notificacion;
        public GameObject panelLlamada;
        public GameObject decisiones;
        public bool celContestado = false;
        public bool celMensaje = false;

        public GameObject opcion;
        public void contestarCel()
        {
            if (!celContestado)
            {
                GetComponent<MeshRenderer>().material = Material1;
            }
            else if(celContestado && !celMensaje)
            {
                GetComponent<MeshRenderer>().material = Material2_Mensaje;
                celMensaje = true;
                notificacion.Play();
                //Comienza toda la ñe de mensajes
                Debug.Log("Comienza el mensaje");
                isActive = true;
                continuarDialogo(posLogica);
                
            }
        }

        public void dejarCelular()
        {
            if(celContestado && !celMensaje)
            {
                GetComponent<MeshRenderer>().material = Material1_Mensaje;
            }
        }

        public void mostrarOpcion()
        {
            opcion.SetActive(true);
            Debug.Log("Muestro opcion");
            GameObject optionText = opcion.transform.Find("Text").gameObject;
            optionText.GetComponent<UnityEngine.UI.Text>().text = respuestas[posLogica];

        }
        public void escogerDecision()
        {
            opcion.SetActive(false);
            Debug.Log("Decision escogida");
            GetComponent<MeshRenderer>().material = materiales[posLogica];
            posLogica++;
            isActive = true;
            continuarDialogo(posLogica);
        }

        public void continuarDialogo(int posActual)
        {
            /*for(int i=posActual; i<logica.Length; i++)
            {
                if (!isActive)
                {
                    break;
                }
                posLogica = i;
                Debug.Log(posLogica);
                Debug.Log(logica[posLogica]);
                if (logica[posLogica] == "Respuesta")
                {
                    mostrarOpcion();
                    isActive = false;
                }
                else
                {
                    cambiarMaterial(materiales[i]);
                }
            }*/
            while (posLogica < logica.Length && isActive) {

                Debug.Log(posLogica);
                Debug.Log(logica[posLogica]);

                if (logica[posLogica] == "Respuesta")
                {
                    isActive = false;
                    mostrarOpcion();
                    
                }
                else
                {
                    StartCoroutine(cambiarMaterial(materiales[posLogica]));
                }
            }
        }

        private void FixedUpdate()
        {
            
        }
        public void mostrarMensaje()
        {
            //cambiarMaterial(materiales[posLogica]);
            if (logica[posLogica] == "Respuesta")
            {
                mostrarOpcion();
                isActive = false;
            }
            else
            {
                cambiarMaterial(materiales[posLogica]);
            }

        }

        public IEnumerator cambiarMaterial(Material material)
        {
            isActive = false;
            yield return new WaitForSeconds(2);
            GetComponent<MeshRenderer>().material = material;
            Debug.Log("Cambio material");
            posLogica++;
            isActive = true;
            notificacion.Play();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cabeza") && !celContestado)
            {
                celContestado = true;
                Llamada.Stop();
                panelLlamada.SetActive(true);
            }
        }
        // Start is called before the first frame update
        public void activarDecision()
        {
            panelLlamada.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            decisiones.SetActive(true);
        }
    }
}

