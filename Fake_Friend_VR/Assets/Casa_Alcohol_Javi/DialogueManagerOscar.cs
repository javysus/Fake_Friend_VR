using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerOscar : MonoBehaviour
    {
        public GameObject dialogueBoxOscar;
        public GameObject Oscar;
        private Animator OscarController;

        public GameObject[] options;
        [Tooltip("Actions to check")]
        public InputAction action = null;

        private string actor;
        int decisiones;
        public bool isActive = false;
        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;

        public AudioSource doorknock;

        //Variables para posicionarse
        bool dialogo1 = false;

        bool irComedor = false;
        static Vector3 darVuelta = new Vector3(4.10f, 0.845f, 12.852f);
        static Vector3 irDerecho = new Vector3(-4.86f, 0.845f, 12.852f);
        static Vector3 comedor = new Vector3(-4.42f, 0.745f, 14.4569998f);

        private Vector3[] goToComedor = { darVuelta, irDerecho, comedor };
        private int posVector = 0;
        public float speed = 0.5f;
        
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


        public void OpenDialogue(DSDialogueSO dialogue)
        {

            hablar.SetActive(false);
            isActive = true;

            currentDialogue = dialogue;

            DisplayMessage();

        }

        void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            actor = currentDialogue.Actor;
            actor_anterior = actor;
            if (actor == "Oscar")
            {
                GameObject parent = dialogueBoxOscar;

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                //Actor actorToDisplay = currentActors[messageToDisplay.actorId];
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

        public void NextMessage()
        {


            Debug.Log("Dialogo al teclear " + currentDialogue);
            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");

                dialogueBoxOscar.LeanScale(Vector3.zero, 1f);
                isActive = false;

                OscarController = Oscar.GetComponent<Animator>();
                Oscar.transform.rotation = new Quaternion(0, 180, 0, 0);
                OscarController.SetTrigger("caminar_trigger");

                irComedor = true;

                //Activar ducha para Cami

                FindObjectOfType<CamiController>().ducharse = true;
                //this.enabled = false;

            }

            else
            {

                DisplayMessage();
            }

        }

        public void DisplayOptions()
        {

            Debug.Log("Interfaz de decision");
            decisiones = currentDialogue.Choices.Count;
            Debug.Log("decisiones " + decisiones);

            for (int i = 0; i < decisiones; i++)
            {
                GameObject optionText = options[i].transform.Find("Text").gameObject;
                optionText.GetComponent<UnityEngine.UI.Text>().text = currentDialogue.Choices[i].Text;

                options[i].SetActive(true);
                options[i].LeanScale(Vector3.one,1f);

            }
            isActive = false;
        }

        public void escogerDecision(int decision)
        {

            Debug.Log("A decidir");
            currentDialogue = currentDialogue.Choices[decision].NextDialogue;
            Debug.Log("Decision " + currentDialogue);
            //Esconder decisiones
            for (int i = 0; i < decisiones; i++)
            {
                options[i].SetActive(false);
                //ptions[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            isActive = true;
            DisplayMessage();


        }
        // Start is called before the first frame update
        void Start()
        {
            doorknock.Play();
        }

        public void caminarComedor(Vector3 dirActual)
        {
            Vector3 movementDirection = dirActual;
            movementDirection.Normalize();

            Vector3 newPos = Vector3.MoveTowards(Oscar.transform.position, dirActual, speed * Time.deltaTime);
            Vector3 direction = (dirActual - Oscar.transform.position);
            Oscar.transform.position = newPos;

            Oscar.transform.rotation = Quaternion.Slerp(Oscar.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            if (irComedor)
            {
                if (Oscar.transform.position == comedor)
                {

                    irComedor = false;
                    
                    Debug.Log("Ha llegado al comedor");
                    OscarController = Oscar.GetComponent<Animator>();
                    //Oscar.transform.rotation = new Quaternion(0, 90, 0, 0);
                    Oscar.transform.Rotate(0, 90, 0);
                    OscarController.SetTrigger("sentarse");

                    //Desactivar componente
                    this.enabled = false;

                }
                else if (Oscar.transform.position == goToComedor[posVector])
                {
                    //Avanzo al siguiente objetivo
                    Debug.Log("Avanzo al siguiente objetivo caminar");

                    if (posVector == 1)
                    {
                        //Desactivo rigidbody y colliders para poder sentarme
                        Rigidbody rigidbody = Oscar.GetComponent<Rigidbody>();
                        rigidbody.isKinematic = true;
                    }
                    posVector += 1;
                }
                else
                {
                    caminarComedor(goToComedor[posVector]);
                }
            }
        }
    }
}