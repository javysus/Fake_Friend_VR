using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaNPC : MonoBehaviour
{
    public GameObject jugador;
    public GameObject panelNPC;
    public GameObject panelNPCMision;
    public bool jugadorCerca;


    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            panelNPC.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;
            panelNPC.SetActive(false);
            panelNPCMision.SetActive(false);
        }
    }

    public void Interactuar()
    {
        panelNPC.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}
