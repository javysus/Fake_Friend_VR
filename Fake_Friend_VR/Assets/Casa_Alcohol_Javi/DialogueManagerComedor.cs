using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerComedor : MonoBehaviour
    {
        public GameObject dialogueBoxOscar;
        public GameObject dialogueBoxMama;
        public GameObject silla;
        public MeshCollider sillaCollider;

        public GameObject Oscar;
        public GameObject Mama;
        public GameObject Cami;
        public Animator CamiAnimator;

        //private Vector3 posicionSentarse = new Vector3(20.5300007f, 1.79900002f, -8.13599968f);
        private Vector3 posicionSentarse = new Vector3(-2.69799995f, 0.949000001f, 15.457f);
        public bool isActive = false;

        //Variables para controlar
        public GameObject[] options;
        private int decisiones;
        public GameObject hablar;
        string actor_anterior;
        string actor;
        DSDialogueSO currentDialogue;
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
        public void OpenDialogue(DSDialogueSO dialogue)
        {
            //Aqui sentar a la Cami
            Cami.transform.position = posicionSentarse;
            //Cami.transform.Rotate(0, 270, 0);
            //Cami.transform.rotation = new Quaternion(0, 270, 0, 0);
            Cami.transform.localRotation = Quaternion.Euler(0, 270, 0);
            CamiAnimator.SetTrigger("sentarse");

            //Mover la silla
            sillaCollider.enabled = false;
            //silla.transform.position = new Vector3(silla.transform.position.x, 0.201f, silla.transform.position.z);

            hablar.SetActive(false);
            currentDialogue = dialogue;
            isActive = true;
            DisplayMessage();
        }

        public void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            actor = currentDialogue.Actor;
            actor_anterior = actor;
            // Start is called before the first frame update

            if (actor == "Oscar")
            {
                //Abrir dialogo de Oscar
                GameObject parent = dialogueBoxOscar;

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);
            }

            else if (actor == "Mama")
            {
                //Abrir dialogo de Oscar
                GameObject parent = dialogueBoxMama;

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);
            }

            if (currentDialogue.Choices[0].Text == "Next Dialogue")
            {
                currentDialogue = currentDialogue.Choices[0].NextDialogue;
                Debug.Log("Siguiente dialogo " + currentDialogue);

                if (currentDialogue.DialogueName == "Mama2")
                {
                    Debug.Log("TEST: Esperar que coma");

                    isActive = false;

                }
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
            if (actor_anterior == "Oscar")
            {
                GameObject parent = dialogueBoxOscar;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Mama")
            {
                GameObject parent = dialogueBoxMama;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                isActive = false;
                //Termina esta interaccion, desactivar componente
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


            for (int i = 0; i < decisiones; i++)
            {
                GameObject optionText = options[i].transform.Find("Text").gameObject;
                optionText.GetComponent<UnityEngine.UI.Text>().text = currentDialogue.Choices[i].Text;

                options[i].SetActive(true);
                options[i].LeanScale(Vector3.one, 1f);

            }

        }

        public void escogerDecision(int decision)
        {
            if (actor_anterior == "Oscar")
            {
                GameObject parent = dialogueBoxOscar;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Mama")
            {
                GameObject parent = dialogueBoxMama;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            currentDialogue = currentDialogue.Choices[decision].NextDialogue;
            Debug.Log("Decision " + currentDialogue);
            //Esconder decisiones
            for (int i = 0; i < decisiones; i++)
            {
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                options[i].SetActive(false);
            }

            isActive = true;
            DisplayMessage();

        }

        


        void Start()
        {
            Debug.Log("TEST Se activa el dialogo de comedor");
        }

        void FixedUpdate()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
