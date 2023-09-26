using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DS
{
    public class ActivarDecision : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject decision_canvas;
        public GameObject caminoLuz;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<BoxCollider>().enabled = false;
                decision_canvas.SetActive(true);
            }
        }

        public void Decidir1()
        {  
            FindObjectOfType<Timer>().Pause = true;
            Debug.Log("Se decidio el de la izquierda");
            caminoLuz.SetActive(true);
            decision_canvas.SetActive(false);
        }
        public void Decidir2()
        {
            Debug.Log("Se decidio el de la Derecha");
            FindObjectOfType<Timer>().Pause = true;
            decision_canvas.SetActive(false);
            
        }
    }
}
