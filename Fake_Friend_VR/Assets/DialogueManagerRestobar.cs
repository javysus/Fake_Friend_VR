using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerRestobar : MonoBehaviour
    {
        public GameObject dialogueBoxNico;
        public GameObject dialogueBoxConi;
        public GameObject dialogueBoxFran;
        public GameObject dialogueBoxMesera;
        public BoxCollider sillaCollider;

        public GameObject Nico;
        public GameObject Coni;
        public GameObject Fran;
        public GameObject Mesera;

        public GameObject Cami;
        public Animator CamiAnimator;
        

        //Movimiento de la mesera
        static Vector3 darVuelta = new Vector3(-0.89200002f, 2.794f, 2.11899996f);
        static Vector3 irDerecho = new Vector3(-0.58f, 2.794f, 5.017f);
        static Vector3 posInicial = new Vector3(0.968999982f, 2.794f, 2.11899996f);
        private bool moverMesera = false;
        private bool moverMeseraInicial = false;
        private Vector3[] goToMesa = { darVuelta, irDerecho};
        private Vector3[] goToInicial = { irDerecho, posInicial };
        public GameObject bandeja;
        public GameObject comidita;
        public GameObject tragos;
        public GameObject tequilazos;
        private bool tragosListos = false;

        private int posVector = 0;
        public float speed = 0.5f;

        public bool isActive = false;

        //Variables para esperar acciones
        public bool esperarAlcohol = false;
        public bool esperarTequila = false;
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

            //Mover la silla
            sillaCollider.enabled = false;
            //Aqui sentar a la Cami
            Vector3 posicionSentarse = new Vector3(0.702963114f, Cami.transform.position.y - 0.2f, 4.45013189f);
            Cami.transform.position = posicionSentarse;

            //Otras opciones para rotar que no funcionaron
            //Cami.transform.Rotate(0, 270, 0);
            //Cami.transform.rotation = new Quaternion(0, 270, 0, 0);

            Cami.transform.localRotation = Quaternion.Euler(0, 0, 0);
            CamiAnimator.SetTrigger("sentarse");

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

            if (actor == "Nico")
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

            else if (actor == "Mesera")
            {
                //Abrir dialogo de Nico
                GameObject parent = dialogueBoxMesera;

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

                if (currentDialogue.DialogueName == "Mesera1")
                {
                    //Mover a la mesera
                    Mesera.GetComponent<Animator>().SetTrigger("caminar");
                    moverMesera = true;
                }

                else if (currentDialogue.DialogueName == "Mesera4")
                {
                    moverMeseraInicial = true;
                    tragosListos = true;
                    //Mover a la mesera
                   
                    //moverMesera = true;
                }

                else if (currentDialogue.DialogueName == "Coni6")
                {
                    //Este dialogo aparece solo despues de tomar cierto tiempo
                    Debug.Log("TEST: Esperar a tomar");
                    esperarAlcohol = true;
                    isActive = false;
                }

                else if (currentDialogue.DialogueName == "Fran9")
                {
                    //Este dialogo aparece solo despues de tomar cierto tiempo
                    tequilazos.SetActive(true);
                    Debug.Log("TEST:  Esperar a tomar");
                    esperarTequila = true;
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

        //Funcion que muestra el siguiente mensaje del dialogo
        public void NextMessage()
        {
            Debug.Log(currentDialogue);
            //Se reconoce el actor anterior para hacer desaparecer su box
            if (actor_anterior == "Nico")
            {
                GameObject parent = dialogueBoxNico;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            }

            else if (actor_anterior == "Coni")
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

            else if (actor_anterior == "Mesera")
            {
                GameObject parent = dialogueBoxMesera;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            }

            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                isActive = false;

                //Mover a Cami fuera de la silla
                Cami.transform.position = new Vector3(1.74000001f, -0.511255383f, 2.31999993f);
                CamiAnimator.SetTrigger("idle");
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
            if (actor_anterior == "Nico")
            {
                GameObject parent = dialogueBoxNico;
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
                options[i].LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                options[i].SetActive(false);
            }

            DisplayMessage();
            isActive = true;


        }
        // Start is called before the first frame update
        void Start()
        {
            //Todos se sientan al comenzar la escena
            Coni.GetComponent<Animator>().SetTrigger("sentarse_trigger");
            Nico.GetComponent<Animator>().SetTrigger("sentarse_trigger");
            Fran.GetComponent<Animator>().SetTrigger("sentarse_trigger");

    
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
            if (moverMesera)
            {
                if (Mesera.transform.position == irDerecho)
                {

                    moverMesera = false;
                    posVector = 0;
                    Debug.Log("TEST: Ha llegado a la mesa");
                    Mesera.transform.Rotate(0, 90, 0);
                    Mesera.GetComponent<Animator>().SetTrigger("idle");

                    DisplayMessage();

                    if (tragosListos)
                    {
                        //Desactivar bandeja
                        bandeja.SetActive(false);

                        //Activar comida de la mesa
                        comidita.SetActive(true);

                        //Activar tragos
                        tragos.SetActive(true);
                    }
                    
                }
                else if (Mesera.transform.position == goToMesa[posVector])
                {
                    //Avanzo al siguiente objetivo
                    Debug.Log("Avanzo al siguiente objetivo caminar");

                    posVector += 1;
                }
                else
                {
                    caminarMesa(goToMesa[posVector], Mesera);
                }
            }

            else if (moverMeseraInicial)
            {
                if (Mesera.transform.position == posInicial)
                {

                    moverMeseraInicial = false;

                    Debug.Log("TEST: Ha llegado a inicial");
                    Mesera.transform.Rotate(0, 0, 0);
                    posVector = 0;
                    //Colocar la bandeja
                    bandeja.SetActive(true);
                    Mesera.GetComponent<Animator>().SetTrigger("caminar_mesera");
                    moverMesera = true;


                }
                else if (Mesera.transform.position == goToInicial[posVector])
                {
                    //Avanzo al siguiente objetivo
                    Debug.Log("Avanzo al siguiente objetivo caminar");

                    posVector += 1;
                }
                else
                {
                    caminarMesa(goToInicial[posVector], Mesera);
                }
            }

            if (esperarAlcohol)
            {
                Debug.Log("TEST a esperar el trago");
                if(FindObjectOfType<DrinkAlcoholBar>().vasos > 0)
                {
                    Debug.Log("TEST Ya se tomo el vaso");
                    esperarAlcohol = false;
                    isActive = true;
                    DisplayMessage();
                }
            } else if (esperarTequila)
            {
                Debug.Log("TEST a esperar el tequila");
                if (FindObjectOfType<DrinkAlcoholBar>().vasos > 1)
                {
                    Debug.Log("TEST Ya se tomo el tequila");
                    esperarTequila = false;
                    isActive = true;
                    DisplayMessage();
                }
            }
        }
    }
}
