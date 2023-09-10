using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DS
{
    public class DialogueTrigger : MonoBehaviour
    {
        public Message[] messages;
        public Actor[] actors;

        /*public void StartDialogue()
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
        }*/
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [System.Serializable]
    public class Message
    {
        public int actorId;
        public string message;
    }
    [System.Serializable]
    public class Actor
    {
        public string name;
    }
}
