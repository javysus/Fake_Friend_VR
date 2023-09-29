using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DS
{
    using ScriptableObjects;
    public class SalidaBar: MonoBehaviour
    {
        public GameObject dialogueBoxConi;
        public GameObject dialogueBoxFran;
        public GameObject dialogueBoxPersonal;

        public GameObject Coni;
        public GameObject Fran;
        public GameObject Personal;

        public GameObject Cami;
        public Animator CamiAnimator;


        //Movimiento de la mesera

        private int posVector = 0;
        public float speed = 0.5f;

        public bool isActive = false;

        //Variables para controlar
        public GameObject[] options;
        private int decisiones;
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

            if (actor == "Coni")
            {
                //Abrir dialogo de Coni
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


            else if (actor == "Francisco")
            {
                //Abrir dialogo de Francisco
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

            else if (actor == "Personal")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxPersonal;

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
                //El siguiente dialogo
                currentDialogue = currentDialogue.Choices[0].NextDialogue;
                Debug.Log("Siguiente dialogo " + currentDialogue);
            }
            else
            {
                //Verificar si el siguiente sea decision para mostrarlo inmediatamente
                DisplayOptions();
            }
        }

        IEnumerator exploraYSeVa()
        {
            //Wait
            yield return new WaitForSeconds(3);

            FindObjectOfType<LevelLoader>().LoadNextLevel();

        }
        //Funcion que muestra el siguiente mensaje del dialogo
        public void NextMessage()
        {
            Debug.Log(currentDialogue);
            //Se reconoce el actor anterior para hacer desaparecer su box

            if (actor_anterior == "Coni")
            {
                GameObject parent = dialogueBoxConi;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Francisco")
            {
                GameObject parent = dialogueBoxFran;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Personal")
            {
                GameObject parent = dialogueBoxPersonal;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            }

            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");

                StartCoroutine(exploraYSeVa());
                isActive = false;
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
                options[i].LeanScale(Vector3.one, 0.5f);
            }
        }

        public void escogerDecision(int decision)
        {
            if (actor_anterior == "Coni")
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
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                options[i].SetActive(false);
            }

            DisplayMessage();
            isActive = true;


        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public void caminarMesa(Vector3 dirActual, GameObject persona)
        {
            Vector3 movementDirection = dirActual;
            movementDirection.Normalize();

            Vector3 newPos = Vector3.MoveTowards(persona.transform.position, dirActual, speed * Time.deltaTime);
            Vector3 direction = (dirActual - persona.transform.position);
            persona.transform.position = newPos;

            persona.transform.rotation = Quaternion.Slerp(persona.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
        }
    }
}
