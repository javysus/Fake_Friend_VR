using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace DS
{
    public class MojojojoController : MonoBehaviour
    {
        public GameObject Cami;
        public Transform Target;
        public DSDialogue afterPelea; 
        public static Vector3 positionCamiEmpuje = new Vector3(-0.209999993f, 2.84899998f, -2.23399997f);
        private static Vector3 positionNico = new Vector3(-0.550000012f, 2.78200006f, 6.38800001f);
        private static Vector3 positionPancho = new Vector3(-0.550000012f, 2.78200006f, 5.1869998f);
        private static Vector3 positionConi = new Vector3(-0.550000012f, 2.78200006f, 4.34899998f);

        public AudioSource musica;

        public AudioSource cachetada;
        public GameObject Nico;
        public GameObject Pancho;
        public GameObject Coni;
        public GameObject Bartender;
        public GameObject SalidaBar;
        public bool caida = false;
        public DSDialogue dialogo_Mojojo;
        public GameObject Timer;
        public GameObject cabezota;
        public bool amigosVienen = false;
        public bool golpear = false;
        public bool mirar = false;
        [SerializeField] float destinationReachedTreshold;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Pelear()
        {
            Debug.Log("Comienza pelea");
            golpear = true;
            //Pegar cachetada de Mojojojo
            //GetComponent<Animator>().SetTrigger("cachetada");
            //Limite de tiempo para golpear, si no, recibe el golpe
            GetComponent<NavMeshAgent>().SetDestination(Target.position);
            cabezota.GetComponent<Golpear>().enabled = true;
            Timer.SetActive(true);

        }

        public void Golpear()
        {
            Debug.Log("Mojojojo golpea");
            cachetada.Play();
            golpear = true;
            GetComponent<NavMeshAgent>().SetDestination(Target.position);
            //GetComponent<Animator>().SetTrigger("cachetada");
            Coni.transform.position = positionConi;
            Pancho.transform.position = positionPancho;
            Nico.transform.position = positionNico;

            Timer.SetActive(false);

            //Activar nuevo dialogo
            SalidaBar.SetActive(true);
            afterPelea.StartDialogue("SalidaBar");
            amigosVienen = true;
        }

        public void RecibirGolpe()
        {
            Debug.Log("Mojojojo es golpeada");
            GetComponent<Animator>().SetTrigger("golpeada");

            Timer.SetActive(false);

            Coni.transform.position = positionConi;
            Pancho.transform.position = positionPancho;
            Nico.transform.position = positionNico;

            //Activar nuevo dialogo
            SalidaBar.SetActive(true);
            afterPelea.StartDialogue("SalidaBar");
            amigosVienen = true;
        }

        public void AmigosVienen()
        {

            Coni.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Coni.GetComponent<NavMeshAgent>().destination = Cami.transform.position;

            Pancho.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Pancho.GetComponent<NavMeshAgent>().destination = Cami.transform.position;

            Nico.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Nico.GetComponent<NavMeshAgent>().destination = Cami.transform.position;

            Bartender.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Bartender.GetComponent<NavMeshAgent>().destination = Cami.transform.position;

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!caida)
                {
                    Cami.transform.position = positionCamiEmpuje;
                    Cami.GetComponent<HeredaXR>().ChangeMoveSpeed(0f);
                    caida = true;

                    //Reproducir animacion de Mojojojo

                    GetComponent<Animator>().SetTrigger("empujada");

                    //Activar dialogo
                    dialogo_Mojojo.StartDialogue("Mojojojo");

                }

                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

            }
        }

        public void FixedUpdate()
        {
            if (amigosVienen)
            {
                AmigosVienen();
            }

            //Distancia de Mojojo a uno
            float distanceToTarget = Vector3.Distance(transform.position, Target.position);
            if (distanceToTarget < 1f && golpear)
            {
                print("Destination reached");
                GetComponent<Animator>().SetTrigger("cachetada");
                golpear = false;
            }

            //Distancia de Coni a uno
            distanceToTarget = Vector3.Distance(Coni.transform.position, Target.position);
            if (distanceToTarget < destinationReachedTreshold && amigosVienen)
            {
                Coni.GetComponent<Animator>().SetTrigger("idle_trigger");
                Pancho.GetComponent<Animator>().SetTrigger("idle_trigger");
                Nico.GetComponent<Animator>().SetTrigger("idle_trigger");
                Bartender.GetComponent<Animator>().SetTrigger("idle_trigger");

                amigosVienen = false;
                mirar = true;
            }
            if (mirar)
            {
                Coni.transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                Pancho.transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                Nico.transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));
                Bartender.transform.LookAt(new Vector3(Target.position.x, Target.position.y, Target.position.z));

                //Apagar musica
                musica.Stop();
            }
            

        }
    }
}