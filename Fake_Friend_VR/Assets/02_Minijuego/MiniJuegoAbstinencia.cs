using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace DS {
    public class MiniJuegoAbstinencia : MonoBehaviour
    {
        public static int num_collider = 0;
        public movimiento_control hereda;
        public AudioSource respiracion;
        public TraficanteMiniJuego traficante;
        public Transform target;
        public GameObject[] acosadores;

        public BoxCollider trigger1;
        public BoxCollider trigger2;
        public BoxCollider trigger3;

        private int acosadores_num = 0;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void FixedUpdate()
        {
            for (int i = 0; i < acosadores_num; i++)
            {
                acosadores[i].GetComponent<NavMeshAgent>().SetDestination(target.position);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }

        public int GetNumCollider()
        {
            return num_collider;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                num_collider++;
                traficante.inTrigger = true;

                //Primero le quitamos la movilidad
                hereda.moveSpeed = 0f;
                if (num_collider == 1)
                {
                    //Aumenta la respiracion (Volumen)
                    respiracion.volume = 0.4f;

                    //Aparecen personas mirando, los primeros 3
                    acosadores_num = 3;

                    trigger1.enabled = false;


                }
                else if (num_collider == 2)
                {
                    respiracion.volume = 0.7f;

                    acosadores_num = 6;

                    trigger2.enabled = false;
                }
                else if (num_collider == 3)
                {
                    respiracion.volume = 1f;

                    acosadores_num = 9;
                    trigger3.enabled = false;
                }

            }
        }

        private void OnTriggerExit(Collider other)
        {
            /*if (other.CompareTag("Player"))
            {
                for (int i = 0; i < acosadores_num; i++)
                {
                    acosadores[i].GetComponent<AcosadorScript>().inTrigger = false;
                    acosadores[i].GetComponent<AcosadorScript>().llegada = false;
                }
            }*/
        }
    }
}