using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerMauroMC : MonoBehaviour
    {
        public GameObject dialogueBoxOscar;
        public GameObject Oscar;
        public Animator animacion;
        public GameObject minijuego;

        public GameObject[] options;
        [Tooltip("Actions to check")]
        public InputAction action = null;

        private string actor;
        int decisiones;
        public bool isActive = false;
        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;
        public GameObject linea_coca;
        public objetivosIzq script_minijuego;

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
            if (actor == "Mauro")
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
                if (currentDialogue.DialogueName=="Mau3")
                {
                    linea_coca.SetActive(true);
                    isActive = false;
                }
                

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

                //Aqui colocar para activar el minijuego
                animacion.SetTrigger("bailar");
                minijuego.SetActive(true);
                script_minijuego.enabled = true;
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
                options[i].LeanScale(Vector3.one, 1f);

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

        // Update is called once per frame
        void FixedUpdate()
        {
            
        }
    }
}
