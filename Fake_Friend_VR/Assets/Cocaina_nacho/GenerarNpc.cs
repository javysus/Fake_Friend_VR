using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarNpc : MonoBehaviour
{
    public List<GameObject> personajes;
    public int cantidadPersonajes = 5;
    public Vector3 minEsquina;
    public Vector3 maxEsquina;
    public LayerMask sueloLayer;

    public bool activar_mirada;
    public List <GameObject> clones;

    void Start()
    {
        activar_mirada = false;
        foreach (GameObject npc in clones)
        {
            LookPlayer script = npc.GetComponent<LookPlayer>();
            script.enabled = false;
        }
        //Invoke("GenerarPersonajesEnSuelo", 15.0f);
        
    }

    public void GenerarPersonajesEnSuelo()
    {
        for (int i = 0; i < cantidadPersonajes; i++)
        {
            // Selecciona un personaje aleatorio de la lista
            int indiceAleatorio = Random.Range(0, personajes.Count);
            GameObject personajePrefab = personajes[indiceAleatorio];

            // Genera una posición aleatoria dentro del área definida
            Vector3 posicionAleatoria = new Vector3(
                Random.Range(minEsquina.x, maxEsquina.x),
                Random.Range(minEsquina.y, maxEsquina.y),
                Random.Range(minEsquina.z, maxEsquina.z)
            );

            // Raycast para encontrar la posición del suelo
            RaycastHit hit;
            if (Physics.Raycast(posicionAleatoria + Vector3.up * 100f, Vector3.down, out hit, Mathf.Infinity, sueloLayer))
            {
                posicionAleatoria = hit.point;
            }

            // Instancia el personaje en la posición encontrada
            clones.Add( Instantiate(personajePrefab, posicionAleatoria, Quaternion.identity));
        }
    }
    void Update()
    {
        if (activar_mirada == true)
        {
            foreach (GameObject npc in clones)
            {
                LookPlayer script = npc.GetComponent<LookPlayer>();
                script.enabled = true;
            }
        }
        
    }
}
