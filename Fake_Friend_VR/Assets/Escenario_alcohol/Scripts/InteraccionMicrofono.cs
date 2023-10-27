using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionMicrofono : MonoBehaviour
{
    public GameObject botonMicrofono;
    public GameObject dialogo;
    public GameObject caminoLuz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            botonMicrofono.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonMicrofono.SetActive(false);
        }
    }

    public void ActivarDialogoMicrofono()
    {
        botonMicrofono.SetActive(false);
        dialogo.SetActive(true);
        caminoLuz.SetActive(false);
    }
}
