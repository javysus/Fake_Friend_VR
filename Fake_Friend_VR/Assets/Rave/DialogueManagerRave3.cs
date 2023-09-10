using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerRave3 : MonoBehaviour
    {
        public GameObject dialogueBoxFenia;
        public GameObject dialogueBoxLuis;
        public GameObject Luis;
        public GameObject Fenia;
        public GameObject Vendedor;
        private Animator LuisController;
        private Animator FeniaController;

        //Movimiento
        private Vector3 vendedor = new Vector3(13.6800003f, 0.0331540108f, 3.36999989f);
        private bool caminarVendedor = false;

        private Vector3 vendedor2 = new Vector3(15f, 0.0331540108f, 4.47700024f);
        private bool caminarVendedor2 = false;

        private bool llegadaFenia = false;
        private bool llegadaLuis = false;
        private int speed = 2;

        private GameObject[] options;
        public GameObject[] optionsFenia;
        public GameObject[] optionsLuis;
        public GameObject NextController;
        [Tooltip("Actions to check")]
        public InputAction action = null;

        private string actor;
        int decisiones;
        public bool isActive = false;
        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;

        public GameObject botonVendedor;

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


            currentDialogue = dialogue;
            isActive = true;
            Luis.GetComponent<LogicaLuisNPC>().dialogo2 = false;
            DisplayMessage();

        }

        void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            actor = currentDialogue.Actor;
            actor_anterior = actor;
            if (actor == "Feña")
            {
                //Abrir dialogo de Fena
                GameObject parent = dialogueBoxFenia;

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
            else if (actor == "Luis")
            {
                //Abrir dialogo de Luis
                GameObject parent = dialogueBoxLuis;

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
        public void NextMessage()
        {

            if (actor_anterior == "Feña")
            {
                GameObject parent = dialogueBoxFenia;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
            else if (actor_anterior == "Luis")
            {
                GameObject parent = dialogueBoxLuis;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            Debug.Log("Dialogo al teclear " + currentDialogue);
            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                isActive = false;
                Luis.GetComponent<LogicaLuisNPC>().accion = true;

                FeniaController = Fenia.GetComponent<Animator>();
                FeniaController.SetTrigger("caminar_trigger");

                LuisController = Luis.GetComponent<Animator>();
                LuisController.SetTrigger("caminar_trigger");

                caminarVendedor = true;
                caminarVendedor2 = true;

                botonVendedor.SetActive(true);
                Vendedor.GetComponent<LogicaGenNPC>().enabled = true;

                NextController.SetActive(true);
                this.enabled = false;

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

            if (actor == "Luis")
            {
                options = optionsLuis;
            }

            else if (actor == "Feña")
            {
                options = optionsFenia;
            }
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
            if (actor_anterior == "Feña")
            {
                GameObject parent = dialogueBoxFenia;
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
            else if (actor_anterior == "Luis")
            {
                GameObject parent = dialogueBoxLuis;
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }
            Debug.Log("A decidir");
            currentDialogue = currentDialogue.Choices[decision].NextDialogue;
            Debug.Log("Decision " + currentDialogue);
            //Esconder decisiones
            for (int i = 0; i < decisiones; i++)
            {
                options[i].SetActive(false);
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            DisplayMessage();
            isActive = true;


        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public void caminarToVendedor(GameObject amigo)
        {
            Vector3 newPos = Vector3.MoveTowards(amigo.transform.position, vendedor, speed * Time.deltaTime);
            amigo.transform.position = newPos;
        }

        void FixedUpdate()
        {
            //caminarBano();
            
            if (caminarVendedor)
            {
                if (Luis.transform.position == vendedor)
                {
                    caminarVendedor = false;
                    Debug.Log("Ha llegado al vendedor");
                    LuisController = Luis.GetComponent<Animator>();
                    LuisController.SetTrigger("idle_trigger");

                    llegadaLuis = true;
                }
                else
                {
                    caminarToVendedor(Luis);
                }
            }

            if (caminarVendedor2)
            {
                if (Fenia.transform.position == vendedor2)
                {
                    caminarVendedor2 = false;
                    Debug.Log("Ha llegado al vendedor");
                    FeniaController = Fenia.GetComponent<Animator>();
                    FeniaController.SetTrigger("idle_trigger");

                    llegadaFenia = true;
                }
                else
                {
                    caminarToVendedor(Fenia);
                }
            }

            if(llegadaFenia && llegadaLuis)
            {
                //No llegan
                Debug.Log("LLegaron");
            }

        }
            // Update is called once per frame
            void Update()
        {

        }
    }
}
