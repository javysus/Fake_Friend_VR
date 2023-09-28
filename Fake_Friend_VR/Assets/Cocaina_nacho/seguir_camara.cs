using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir_camara : MonoBehaviour
{
    public Transform personaje; // Referencia al Transform del personaje a seguir
    public Vector3 offset = new Vector3(0, 2, -5); // Ajuste de posición de la cámara

    public float velocidadRotacion = 5.0f; // Velocidad de rotación de la cámara

    private void Update()
    {
        if (personaje == null)
        {
            Debug.LogWarning("La referencia al personaje no está configurada.");
            return;
        }

        // Obtén la posición deseada para la cámara
        Vector3 posicionDeseada = personaje.position + offset;

        // Interpola suavemente la posición de la cámara hacia la posición deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * velocidadRotacion);

        // Asegúrate de que la cámara siempre mire hacia el personaje
        transform.LookAt(personaje);
    }
}

