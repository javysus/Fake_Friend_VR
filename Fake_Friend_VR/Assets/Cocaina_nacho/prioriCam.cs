using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class prioriCam : MonoBehaviour
{
    public Camera cameraA; // La primera cámara
    public Camera cameraB; // La segunda cámara
    //public float tiempoEspera = 5.0f; // El tiempo en segundos antes de cambiar la prioridad
    private bool cambioRealizado = false;

    private void Start()
    {
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisiono");
            if (!cambioRealizado)
            {
                // Establecer la nueva prioridad (profundidad) para las cámaras
                cameraA.depth = -1; // Por ejemplo, prioridad 1 para la cámara A
                cameraB.depth = 0; // Prioridad 0 para la cámara B (puede ser diferente según tus necesidades)

                cambioRealizado = true; // Evitar que se realice el cambio nuevamente
            }
        }
        else
        {
            Debug.Log("No Colisiono");
        }
    }
            
}
