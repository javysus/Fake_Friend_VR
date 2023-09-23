using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucharseAlcohol : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject jugador;
    public GameObject panelDucharse;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        panelDucharse.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro en el triggerEnter");
        if (other.tag == "Player")
        {
            Debug.Log("Entro en el PLayer");
            panelDucharse.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            panelDucharse.SetActive(false);
        }
    }

    public void Ducharse()
    {

    }
}
