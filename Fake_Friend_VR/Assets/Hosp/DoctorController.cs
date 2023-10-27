using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DS
{
    public class DoctorController : MonoBehaviour
    {
        public GameObject DSDialogue;

        private void Start()
        {
            DSDialogue.GetComponent<DSDialogue>().StartDialogue("medico");
        }
    }
}
