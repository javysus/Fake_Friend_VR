using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Empujar : MonoBehaviour
{
    public GameObject hermano;
    public GameObject conversacion;
    public Transform puerta;
    public GameObject caminoLuz;
    public GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        conversacion.SetActive(false);
        if (other.CompareTag("Mano")){
            hermano.GetComponent<Animator>().SetTrigger("Caerse");
            caminoLuz.GetComponent<NavMeshCaminoLuz>().ActualizarCamino(puerta);
            text.GetComponent<Text>().text = "Sal de la casa y ve donde tu vecino";
        }
    }
}
