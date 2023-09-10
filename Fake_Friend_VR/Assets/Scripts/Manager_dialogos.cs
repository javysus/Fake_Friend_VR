using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_dialogos : MonoBehaviour
{
    public GameObject dialogueBoxes;
    
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;
        Debug.Log("TEST Comenzó la conversación, se han cargado " + messages.Length);
        Debug.Log(currentMessages[activeMessage].message);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        
        /*
        if(messageToDisplay.actorId == 0)
        {
            //Abrir dialogo de Fena
            GameObject parent = GameObject.FindGameObjectsWithTag("Feña_Dialogo")[0];
            GameObject actorName = parent.transform.Find("Actor").gameObject;
            GameObject messageText = parent.transform.Find("Message").gameObject;
            GameObject backgroundBox = parent;
            
            messageText.GetComponent<UnityEngine.UI.Text>().text = messageToDisplay.message;
            Actor actorToDisplay = currentActors[messageToDisplay.actorId];
            actorName.GetComponent<UnityEngine.UI.Text>().text = actorToDisplay.name;
        }

        else if (messageToDisplay.actorId == 1)
        {
            //Abrir dialogo de Luis
            GameObject parent = GameObject.FindGameObjectsWithTag("Luis_Dialogo")[0];
            GameObject actorName = parent.transform.Find("Actor").gameObject;
            GameObject messageText = parent.transform.Find("Message").gameObject;
            GameObject backgroundBox = parent;

            messageText.GetComponent<UnityEngine.UI.Text>().text = messageToDisplay.message;
            Actor actorToDisplay = currentActors[messageToDisplay.actorId];
            actorName.GetComponent<UnityEngine.UI.Text>().text = actorToDisplay.name;
        }
        */
        messageText.text = messageToDisplay.message;
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;

    }

    public void NextMessage()
    {
        activeMessage++;
        Debug.Log(activeMessage);
        Debug.Log(currentMessages);
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended");
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            NextMessage();
        }*/
    }
}
