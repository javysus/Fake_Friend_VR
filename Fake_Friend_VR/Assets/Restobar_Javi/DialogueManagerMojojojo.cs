using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;
namespace DS
{
    using ScriptableObjects;
    public class DialogueManagerMojojojo : MonoBehaviour
    {
        public GameObject dialogueBoxMojojojo;
        public GameObject Mojojojo;
        private Animator MojojojoController;

        public GameObject[] options;
        [Tooltip("Actions to check")]
        public InputAction action = null;

        private string actor;
        int decisiones;
        public bool isActive = false;
        string actor_anterior;
        DSDialogueSO currentDialogue;

        private int posVector = 0;
        public float speed = 0.5f;

        public bool pelea = false;

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


            isActive = true;

            currentDialogue = dialogue;

            DisplayMessage();

        }

        void DisplayMessage()
        {

            string dialogo = currentDialogue.Text;
            actor = currentDialogue.Actor;
            actor_anterior = actor;
            if (actor == "Loca")
            {
                GameObject parent = dialogueBoxMojojojo;

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

        IEnumerator exploraYSeVa()
        {
            //Wait
            yield return new WaitForSeconds(7f);

            FindObjectOfType<LevelLoader>().LoadNextLevel();

        }
        public void NextMessage()
        {


            Debug.Log("Dialogo al teclear " + currentDialogue);
            if (currentDialogue == null)
            {
                Debug.Log("Conversation ended");
                GameObject parent = dialogueBoxMojojojo;
                isActive = false;
                //parent.SetActive(false);
                parent.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
                if (pelea)
                {
                    //Comienza pelea
                    FindObjectOfType<MojojojoController>().Pelear();
                }
                else
                {
                    MojojojoController.SetTrigger("caminar_trigger");
                    Mojojojo.GetComponent<NavMeshAgent>().SetDestination(new Vector3(-6.23000002f, 2.72000003f, -2.55999994f));
                    StartCoroutine(exploraYSeVa());
                }
                
                

                
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

            if (currentDialogue.DialogueName == "Mojojojo3")
            {
                pelea = true;
            }
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
        }

        public void caminarComedor(Vector3 dirActual)
        {
            Vector3 movementDirection = dirActual;
            movementDirection.Normalize();

            Vector3 newPos = Vector3.MoveTowards(Mojojojo.transform.position, dirActual, speed * Time.deltaTime);
            Vector3 direction = (dirActual - Mojojojo.transform.position);
            Mojojojo.transform.position = newPos;

            Mojojojo.transform.rotation = Quaternion.Slerp(Mojojojo.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);

        }
        // Update is called once per frame
        void FixedUpdate()
        {
            
        }
    }
}