using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPanelHablar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelHablar;
    public GameObject jugador;
    private bool conversando = false;


    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreLayerCollision(2, 7);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && conversando == false)
        {
            panelHablar.SetActive(true);
            conversando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelHablar.SetActive(false);
            conversando = false;
        }
    }
}
