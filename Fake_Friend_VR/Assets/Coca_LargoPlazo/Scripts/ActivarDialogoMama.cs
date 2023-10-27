using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS
{
    public class ActivarDialogoMama : MonoBehaviour
    {
        public GameObject DSDialogue;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                DSDialogue.GetComponent<DSDialogue>().StartDialogue("Mama");
            }
        }
    }
}
