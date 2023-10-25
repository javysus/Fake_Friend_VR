using UnityEngine;

namespace DS
{
    using ScriptableObjects;

    public class DSDialogue : MonoBehaviour
    {
        /* Dialogue Scriptable Objects */
        [SerializeField] private DSDialogueContainerSO dialogueContainer;
        [SerializeField] private DSDialogueGroupSO dialogueGroup;
        [SerializeField] private DSDialogueSO dialogue;

        /* Filters */
        [SerializeField] private bool groupedDialogues;
        [SerializeField] private bool startingDialoguesOnly;

        /* Indexes */
        [SerializeField] private int selectedDialogueGroupIndex;
        [SerializeField] private int selectedDialogueIndex;

        public void StartDialogue(string dialogo)
        {
            if (dialogo == "Rave1")
            {
                FindObjectOfType<DialogueManagerRave1>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Rave2")
            {
                FindObjectOfType<DialogueManagerRave2>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Rave3")
            {
                FindObjectOfType<DialogueManagerRave3>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Josefa")
            {
                FindObjectOfType<DialogueManagerJosefA>().OpenDialogue(dialogue);
            }
            else if(dialogo == "Alcohol1")
            {
                FindObjectOfType<DialogueManagerAlcohol>().OpenDialogue(dialogue);
            } else if (dialogo == "Alcohol2")
            {
                FindObjectOfType<DialogueManagerAlcohol2>().OpenDialogue(dialogue);
            }else if (dialogo == "Alcohol3")
            {
                FindObjectOfType<DialogueManagerAlcohol3>().OpenDialogue(dialogue);
            } else if (dialogo == "Coni")
            {
                FindObjectOfType<DMCami>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Diego")
            {
                FindObjectOfType<DMDiego>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Oscar")
            {
                FindObjectOfType<DialogueManagerOscar>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Comedor")
            {
                FindObjectOfType<DialogueManagerComedor>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Restobar")
            {
                FindObjectOfType<DialogueManagerRestobar>().OpenDialogue(dialogue);
            }
            else if (dialogo == "Mojojojo")
            {
                FindObjectOfType<DialogueManagerMojojojo>().OpenDialogue(dialogue);
            } else if (dialogo == "SalidaBar")
            {
                FindObjectOfType<SalidaBar>().OpenDialogue(dialogue);
            } else if (dialogo == "OscarLargoPlazo")
            {
                FindObjectOfType<DialogueManagerOscarLargoPlazo>().OpenDialogue(dialogue);
            }
            else
            {
                FindObjectOfType<DialogueManager>().OpenDialogue(dialogue);
            }
        }

        public void nextNode()
        {
            string dialogo = dialogue.Text;
            string actor = dialogue.Actor;
            Debug.Log(dialogo);
            Debug.Log(actor);

            Debug.Log(dialogue.Choices.Count);
            Debug.Log("Nombre de la decision " + dialogue.Choices[0].Text);
            Debug.Log(dialogue.Choices[0].NextDialogue);
            Debug.Log(dialogue.Choices[0].NextDialogue.Text);

           
        }
    }

    
}