using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerAlcohol : MonoBehaviour
    {
        public GameObject dialogueBoxNico;
        public GameObject Nico;
        public GameObject Coni;
        private bool empezar_abrazo;
        private Animator NicoController;
        private Vector3 banio = new Vector3(-2.8f, 0f, -4f);
        private Vector3 amigos = new Vector3(-2.38f, 0f, -6.82f);
        public float force;
        public float speed = 2;
        private Rigidbody rb;
        //public Text actorName;
        //public Text messageText;
        //public RectTransform backgroundBox;

        Message[] currentMessages;
        Actor[] currentActors;
        int activeMessage = 0;
        int decisiones;
        public static bool isActive = false;
        public GameObject[] options;
        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;

        bool dialogo1 = false;
        bool dialogo2 = false;
        bool dialogo3 = false;

        bool irBanio = false;
        bool irAmigos = false;

        public GameObject NextController;
        [Tooltip("Actions to check")]
        public InputAction action = null;

        private void Awake()
        {
            action.started += Pressed;
        }

        private void OnDestroy()
        {
            action.started -= Pressed;
        }

        private void OnEnable()
        {
            action.Enable();
        }

        private void OnDisable()
        {
            action.Disable();
        }

        private void Pressed(InputAction.CallbackContext context)
        {
            if (isActive)
            {
                NextMessage();
            }
        }
        /*public void OpenDialogue(Message[] messages, Actor[] actors)
        {
            currentMessages = messages;
            currentActors = actors;
            activeMessage = 0;

            isActive = true;
            Debug.Log("TEST Comenzó la conversación, se han cargado " + messages.Length);
            Debug.Log(currentMessages[activeMessage].message);
            DisplayMessage();
        }*/


        public void OpenDialogue(DSDialogueSO dialogue)
        {
            hablar.SetActive(false);
            currentDialogue = dialogue;
            activeMessage = 0;
            isActive = true;
            DisplayMessage();
        }

        void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            string actor = currentDialogue.Actor;
            actor_anterior = actor;
            if (actor == "Nicolas")
            {
                //Abrir dialogo de Nico
                //GameObject parent = GameObject.FindGameObjectsWithTag("Feña_Dialogo")[0];
                GameObject parent = dialogueBoxNico;
                parent.SetActive(true);

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;  
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);

            }
         

            Debug.Log("Dialogo actual " + currentDialogue);
            if (currentDialogue.Choices[0].Text == "Next Dialogue")
            {
                currentDialogue = currentDialogue.Choices[0].NextDialogue;
                Debug.Log("Siguiente dialogo " + currentDialogue);
            }
            else
            {
                //Verificar si el siguiente sea decision para mostrarlo inmediatamente
                DisplayOptions();
            }

        }

        //Funcion que muestra el siguiente mensaje del dialogo
        public void NextMessage()
        {
            Debug.Log(currentDialogue);
            //Se reconoce el actor anterior para hacer desaparecer su box
            if (actor_anterior == "Nicolas")
            {
                GameObject parent = dialogueBoxNico;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            Debug.Log("Dialogo al teclear " + currentDialogue);
            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                isActive = false;
                /*NicoController = Nico.GetComponent<Animator>();
                NicoController.SetTrigger("caminar_trigger");
                irBanio = true;*/
                //caminarBano();
                /*
                LuisController = Luis.GetComponent<Animator>();
                SplineFollower splineFollower = Luis.GetComponent<SplineFollower>();
                splineFollower.enabled = true;
                LuisController.SetTrigger("caminar_trigger");*/

                //Termina esta interaccion, desactivar componente
                Coni.GetComponent<LogicaConiNPC>().abrazo = true;
                NextController.SetActive(true); //Se activa el siguiente
                this.enabled = false;



            }
            else if(currentDialogue.DialogueName == "NicolasBano")
            {
                Debug.Log("A caminar");
                //NicoController = Nico.GetComponent<Animator>();
                //SplineFollower splineFollower = Nico.GetComponent<SplineFollower>();
                //splineFollower.enabled = true;
                NicoController = Nico.GetComponent<Animator>();
                NicoController.SetTrigger("caminar_trigger");
                irBanio = true;
                //isActive = false;
                
            }

            else if (currentDialogue.DialogueName == "Nicolas6")
            {
                Debug.Log("A caminar");
                //NicoController = Nico.GetComponent<Animator>();
                //SplineFollower splineFollower = Nico.GetComponent<SplineFollower>();
                //splineFollower.enabled = true;
                NicoController = Nico.GetComponent<Animator>();
                NicoController.SetTrigger("caminar_trigger");
                irAmigos = true;
                //isActive = false;

            }
            else
            {

                DisplayMessage();
            }

        }



        public void DisplayOptions()
        {

            Debug.Log("Interfaz de decision");
            isActive = false;
            decisiones = currentDialogue.Choices.Count;

            for (int i = 0; i < decisiones; i++)
            {
                GameObject optionText = options[i].transform.Find("Text").gameObject;
                optionText.GetComponent<UnityEngine.UI.Text>().text = currentDialogue.Choices[i].Text;

                options[i].SetActive(true);
                options[i].LeanScale(Vector3.one, 0.3f);


            }
        }

        public void escogerDecision(int decision)
        {
            if (actor_anterior == "Nicolas")
            {
                GameObject parent = dialogueBoxNico;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            Debug.Log("A decidir");
            currentDialogue = currentDialogue.Choices[decision].NextDialogue;
            Debug.Log("Decision " + currentDialogue);
            //Esconder decisiones
            for (int i = 0; i < decisiones; i++)
            {
                //GameObject optionText = options[i].transform.Find("Text").gameObject;
                //optionText.GetComponent<UnityEngine.UI.Text>().text = currentDialogue.Choices[i].Text;
                options[i].SetActive(false);
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            DisplayMessage();
            isActive = true;


        }

        public void caminarBano()
        {
            Vector3 movementDirection = banio;
            movementDirection.Normalize();


            //Vector3 f = banio - NicoCuerpo.transform.position;
            //f = f.normalized;
            //f = f * force;
            /*NicoController = Nico.GetComponent<Animator>();
            NicoController.SetTrigger("caminar_trigger");*/


            Vector3 newPos = Vector3.MoveTowards(Nico.transform.position, banio, speed * Time.deltaTime);
            Vector3 direction = (banio - Nico.transform.position);
            Nico.transform.position = newPos;

            Nico.transform.rotation = Quaternion.Slerp(Nico.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

            //NicoCuerpo.transform.LookAt(banio);
            //rb.AddForce(f);


        }

        public void caminarAmigos()
        {
            Vector3 newPos = Vector3.MoveTowards(Nico.transform.position, amigos, speed * Time.deltaTime);
            Vector3 direction = (amigos - Nico.transform.position);
            Nico.transform.position = newPos;

            Nico.transform.rotation = Quaternion.Slerp(Nico.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        void FixedUpdate()
        {
            //caminarBano();
            if (irBanio)
            {
                if (Nico.transform.position == banio)
                {
                    irBanio = false;
                    Debug.Log("Ha llegado al baño");
                    NicoController = Nico.GetComponent<Animator>();
                    NicoController.SetTrigger("idle_trigger");

                    Debug.Log("A mostrar mensaje");
                    DisplayMessage();
                }
                else
                {
                    caminarBano();
                }
            }

            if (irAmigos)
            {
                if (Nico.transform.position == amigos)
                {
                    irAmigos = false;
                    Debug.Log("Ha llegado donde sus amigos");
                    NicoController = Nico.GetComponent<Animator>();
                    NicoController.SetTrigger("idle_trigger");

                    Debug.Log("A mostrar mensaje");
                    DisplayMessage();

                    
                }
                else
                {
                    caminarAmigos();
                }
            }

        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}