using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public Trigger_dialogos trigger;
    public GameObject jugador;
    public GameObject panelNPC;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        panelNPC.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro en el triggerEnter");
        if (other.tag == "Player")
        {
            Debug.Log("Entro en el PLayer");
            panelNPC.SetActive(true);
            trigger.StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panelNPC.SetActive(false);
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entro en el collisionEnter");
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("Entro en el PLayer");
            trigger.StartDialogue();
        }
    }
    */
}
