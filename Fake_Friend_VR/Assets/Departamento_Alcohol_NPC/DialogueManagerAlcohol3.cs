using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerAlcohol3 : MonoBehaviour
    {
        public GameObject dialogueBoxNico;
        public GameObject dialogueBoxConi;
        public GameObject dialogueBoxDiego;
        public GameObject dialogueBoxFran;
        public GameObject timer;

        public GameObject Nico;
        public GameObject Coni;
        public GameObject Diego;
        public GameObject Francisco;

        private Vector3 mesa = new Vector3(-5.82000017f, 0f, -8.21000004f);
        private Vector3 mesaDiego = new Vector3(-5.82999992f, 0f, -9.68999958f);
        private Vector3 mesaNico = new Vector3(-6.74499989f, 0f, -7.81500006f);
        private Vector3 mesaFrancisco = new Vector3(-6.67999983f, 0f, -9.52999973f);

        private bool llegada = false;
        private bool llegadaDiego = false;
        private bool llegadaNico = false;
        private bool llegadaFrancisco = false;
        private bool esperar = false;
        public GameObject Vaso;
        public GameObject VasoCollider;
        public float speed = 2;

        public bool isActive = false;

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
            hablar.SetActive(false);
            currentDialogue = dialogue;
            isActive = true;
            DisplayMessage();
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
                Nico.GetComponent<LogicaNicolasNPC>().culturaChupistica = false;
                Coni.GetComponent<LogicaConiNPC>().culturaChupistica = false;
                Francisco.GetComponent<LogicaNicolasNPC>().culturaChupistica = false;
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
            timer.SetActive(true);
        

            for (int i = 0; i < decisiones; i++)
            {
                if(currentDialogue.Choices[i].Text=="Sin Tiempo")
                {
                    continue;
                }
                GameObject optionText = options[i].transform.Find("Text").gameObject;
                optionText.GetComponent<UnityEngine.UI.Text>().text = currentDialogue.Choices[i].Text;

                options[i].SetActive(true);
                options[i].LeanScale(Vector3.one, 0.3f);

            }

        }

        public void escogerDecision(int decision)
        {
            timer.SetActive(false);
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
            if (currentDialogue.DialogueName == "Coni1")
            {
                if (decision==-1 || decision == 1)
                {
                    //Perdio, debe tomar
                    Vaso.SetActive(true);
                    esperar = true;
                }
            }
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

            //ESPERAR
            /*
            DisplayMessage();
            isActive = true;*/


        }

        public void caminarMesa(string persona)
        {
            if (persona == "Coni")
            {
                Vector3 newPos = Vector3.MoveTowards(Coni.transform.position, mesa, speed * Time.deltaTime);
                Vector3 direction = (mesa - Coni.transform.position);
                Coni.transform.position = newPos;

                Coni.transform.rotation = Quaternion.Slerp(Coni.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
            }

            else if (persona == "Diego")
            {
                Vector3 newPos = Vector3.MoveTowards(Diego.transform.position, mesaDiego, speed * Time.deltaTime);
                Vector3 direction = (mesaDiego - Diego.transform.position);
                Diego.transform.position = newPos;

                Diego.transform.rotation = Quaternion.Slerp(Diego.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
            }
            else if (persona == "Nico")
            {
                Vector3 newPos = Vector3.MoveTowards(Nico.transform.position, mesaNico, speed * Time.deltaTime);
                Vector3 direction = (mesaNico - Nico.transform.position);
                Nico.transform.position = newPos;

                Nico.transform.rotation = Quaternion.Slerp(Nico.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
            }
            else if (persona == "Francisco")
            {
                Vector3 newPos = Vector3.MoveTowards(Francisco.transform.position, mesaFrancisco, speed * Time.deltaTime);
                Vector3 direction = (mesaFrancisco - Francisco.transform.position);
                Francisco.transform.position = newPos;

                Francisco.transform.rotation = Quaternion.Slerp(Francisco.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
            }

        }


        void Start()
        {
            Coni.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Nico.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Francisco.GetComponent<Animator>().SetTrigger("caminar_trigger");
            Diego.GetComponent<Animator>().SetTrigger("caminar_trigger");

            Nico.GetComponent<LogicaNicolasNPC>().culturaChupistica = true;
            Coni.GetComponent<LogicaConiNPC>().culturaChupistica = true;
            Francisco.GetComponent<LogicaNicolasNPC>().culturaChupistica = true;
        }

        void FixedUpdate()
        {
            if (Coni.transform.position == mesa && !llegada)
            {
                //Coni.transform.Rotate(0, 230, 0, Space.Self);
                Coni.transform.rotation = new Quaternion(0, 180, 0, 0);
                Coni.GetComponent<Animator>().SetTrigger("sentarse_trigger");
                llegada = true;
            }

            else if (!llegada)
            {
                caminarMesa("Coni");
            }

            if (Nico.transform.position == mesaNico && !llegadaNico)
            {
                //Coni.transform.Rotate(0, 230, 0, Space.Self);
                Nico.transform.rotation = new Quaternion(0, 180, 0, 0);
                Nico.GetComponent<Animator>().SetTrigger("sentarse_trigger");
                llegadaNico = true;
            }

            else if (!llegadaNico)
            {
                caminarMesa("Nico");
            }

            if (Diego.transform.position == mesaDiego && !llegadaDiego)
            {
                //Coni.transform.Rotate(0, 230, 0, Space.Self);
                Diego.transform.rotation = new Quaternion(0, 0, 0, 0);
                Diego.GetComponent<Animator>().SetTrigger("sentarse_trigger");
                llegadaDiego = true;
            }

            else if (!llegadaDiego)
            {
                caminarMesa("Diego");
            }

            if (Francisco.transform.position == mesaFrancisco && !llegadaFrancisco)
            {
                //Coni.transform.Rotate(0, 230, 0, Space.Self);
                Francisco.transform.rotation = new Quaternion(0, 0, 0, 0);
                Francisco.GetComponent<Animator>().SetTrigger("sentarse_trigger");
                llegadaFrancisco = true;
            }

            else if (!llegadaFrancisco)
            {
                caminarMesa("Francisco");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (esperar)
            {
                Debug.Log("Acabas de apretar espacio");
                NextMessage();
            }
        }
    }
}