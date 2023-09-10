using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlejarseJugador : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador; 
    bool estarAlerta;
    public Transform jugador;//target position
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarAlerta)
        {
            
            
            Vector3 direccion = transform.position - jugador.position; // Calcula la dirección desde el NPC hacia el jugador
            direccion.Normalize(); // Normaliza la dirección para tener una magnitud de 1

            // Calcula la nueva posición del NPC hacia la dirección opuesta (alejándose del jugador)
            Vector3 nuevaPosicion = transform.position + direccion * velocidad * Time.deltaTime;

            transform.LookAt(new Vector3(jugador.position.x,transform.position.y,jugador.position.z));
            // Actualiza la posición del NPC
            transform.position = nuevaPosicion;

        }
        
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,rangoDeAlerta);
    }

    
}
