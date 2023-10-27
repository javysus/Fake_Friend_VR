using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PresentadoraNavMeshController : MonoBehaviour
{
    public Transform objetivo;
    public GameObject dialogo;
    public AudioSource aplausos;
    public GameObject paredes_invisibles;
    public GameObject caminoLuz;
    public GameObject player;

    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        player.GetComponent<HeredaXR>().moveSpeed = 1f;
    }

    public void PresentadoraSeVa()
    {
        dialogo.SetActive(false);
        agente.SetDestination(objetivo.position);
        aplausos.Play();
        paredes_invisibles.SetActive(false);
        caminoLuz.SetActive(true);
    }
}
