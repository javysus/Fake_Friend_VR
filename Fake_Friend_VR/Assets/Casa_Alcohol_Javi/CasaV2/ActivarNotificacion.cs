using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.Interaction.Toolkit
{
    public class ActivarNotificacion : MonoBehaviour
    {
        public AudioSource notificacion;
        public GameObject celular;
        public GameObject caminoLuz;
        public GameObject self;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                notificacion.Play();
                celular.GetComponent<XRGrabInteractable>().enabled = true;
                caminoLuz.SetActive(false);
                caminoLuz.SetActive(true);
                caminoLuz.GetComponent<Animator>().ResetTrigger("Habitacion");
                caminoLuz.GetComponent<Animator>().SetTrigger("Celular");
                self.SetActive(false);
            }
        }
    }
}
