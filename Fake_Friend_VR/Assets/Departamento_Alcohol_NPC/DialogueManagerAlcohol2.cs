using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerAlcohol2 : MonoBehaviour
    {
        public GameObject dialogueBoxNico;
        public GameObject dialogueBoxConi;
        public GameObject dialogueBoxDiego;
        public GameObject dialogueBoxFran;

        public GameObject Nico;
        public GameObject Coni;
        public GameObject Diego;
        public GameObject Fran;

        public GameObject Vaso;
        private Vector3 mesa = new Vector3(-5.82000017f, 0f, -8.21000004f);
        private bool llegada = false;
        public float speed = 2;

        int decisiones;
        public static bool isActive = false;

        public GameObject[] optionsNico;
        public GameObject[] optionsDiego;
        public GameObject[] optionsConi;
        private GameObject[] options;

        private string actor;

        public GameObject hablar;
        string actor_anterior;
        DSDialogueSO currentDialogue;

        public GameObject NextController;
        public GameObject NextController2;
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
            hablar.SetActive(false);
            currentDialogue = dialogue;
            isActive = true;
            DisplayMessage();

            Debug.Log("Coni te abraza");
            Coni.GetComponent<Animator>().SetTrigger("abrazar");
            Coni.GetComponent<LogicaConiNPC>().abrazo = false;
        }

        void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            actor = currentDialogue.Actor;
            actor_anterior = actor;
            // Start is called before the first frame update

            if (actor == "Nicolas")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxNico;
   
                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);
            }

            else if (actor == "Coni")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxConi;

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);
            }

            else if (actor == "Diego")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxDiego;

                GameObject actorName = parent.transform.Find("Actor").gameObject;
                GameObject messageText = parent.transform.Find("Message").gameObject;
                GameObject backgroundBox = parent;
                backgroundBox.LeanScale(Vector3.one, 0.5f);

                messageText.GetComponent<UnityEngine.UI.Text>().text = dialogo;
                actorName.GetComponent<UnityEngine.UI.Text>().text = actor;

                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 0, 0);
                LeanTween.textAlpha(messageText.GetComponent<UnityEngine.UI.Text>().rectTransform, 1, 0.5f);
            }

            else if (actor == "Francisco")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxFran;

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

            else if (actor_anterior == "Diego")
            {
                GameObject parent = dialogueBoxDiego;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Coni")
            {
                GameObject parent = dialogueBoxConi;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Francisco")
            {
                GameObject parent = dialogueBoxFran;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                isActive = false;
                //Termina esta interaccion, desactivar componente
                //Activar vaso
                Vaso.SetActive(true);
                //Activar siguiente controlador
                NextController.SetActive(true);
                NextController2.SetActive(true);
                Coni.GetComponent<LogicaConiNPC>().dialogoConi = true;
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

            if (actor == "Nicolas")
            {
                options = optionsNico;
            }

            else if (actor == "Diego")
            {
                options = optionsDiego;
            }

            else if (actor == "Coni")
            {
                options = optionsConi;
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
            if (actor_anterior == "Nicolas")
            {
                GameObject parent = dialogueBoxNico;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Diego")
            {
                GameObject parent = dialogueBoxDiego;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Coni")
            {
                GameObject parent = dialogueBoxConi;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Francisco")
            {
                GameObject parent = dialogueBoxFran;
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
                
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                options[i].SetActive(false);
            }

            DisplayMessage();
            isActive = true;


        }


        void Start()
        {
            //Coni.GetComponent<Animator>().SetTrigger("caminar_trigger");
            
        }

        void FixedUpdate()
        {
            /*if(Coni.transform.position == mesa && !llegada)
            {
                //Coni.transform.Rotate(0, 230, 0, Space.Self);
                Coni.transform.rotation = new Quaternion(0, 180, 0,0);
                Coni.GetComponent<Animator>().SetTrigger("sentarse_trigger");
                llegada = true;
            }

            else if(!llegada)
            {
                caminarMesa();
            }*/
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isActive)
            {
                Debug.Log("Acabas de apretar espacio");
                NextMessage();
            }
        }
    }
}