using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerRave1 : MonoBehaviour
    {
        public GameObject dialogueBoxFenia;
        public GameObject dialogueBoxLuis;
        public GameObject pill;
        public GameObject Luis;
        public GameObject Fenia;
        private Animator LuisController;
        private Animator FeniaController;
        public GameObject NextController;
        private GameObject[] options;
        public GameObject[] optionsFenia;
        public GameObject[] optionsLuis;

        [Tooltip("Actions to check")]
        public InputAction action = null;

        private string actor;
        int decisiones;
        public bool isActive = false;
        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;


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
            Luis.GetComponent<LogicaLuisNPC>().dialogo0 = false;
            
            currentDialogue = dialogue;
            isActive = true;
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
            Debug.Log("Actividad " + isActive);
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
                //Luis.GetComponent<LogicaLuisNPC>().dialogo1 = true;
                pill.SetActive(true);
                Luis.GetComponent<Animator>().SetTrigger("dar");
                //LevelLoader.GetComponent<BoxCollider>().enabled = true;
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

        // Update is called once per frame
        void Update()
        {

        }
    }
}
