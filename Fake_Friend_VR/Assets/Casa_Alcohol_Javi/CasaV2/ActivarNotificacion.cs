using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.Interaction.Toolkit
{
    public class ActivarNotificacion : MonoBehaviour
    {
        public AudioSource notificacion;
        public GameObject celular;
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
                this.enabled=false;
            }
        }
    }
}
