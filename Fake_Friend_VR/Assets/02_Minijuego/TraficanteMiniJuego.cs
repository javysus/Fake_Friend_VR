using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace DS {
    public class TraficanteMiniJuego : MonoBehaviour
    {
        public bool llegada = false;
        public bool inTrigger = false;
        public int num_collider;
        public Transform target;
        public DialogueManagerTraficanteJuego dmanager;
        public MiniJuegoAbstinencia jueguito;
        public DSDialogue eldialoguito;
    // Start is called before the first frame update
    void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }

        private void FixedUpdate()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
        // Update is called once per frame
        void Update()
        {

            if (Vector3.Distance(transform.position, target.position) <= 4 && !llegada && inTrigger)
            {
                Debug.Log("At Destination");
                transform.LookAt(target.position);

                llegada = true;

                num_collider = jueguito.GetNumCollider();

                if (num_collider == 1)
                {
                    //Abrir dialogo
                    Debug.Log("Abrir primer dialogo");
                    eldialoguito.StartDialogue("Minijuego");
                }
                else
                {
                    dmanager.DisplayMessage();
                }
            }
        }
    }
}