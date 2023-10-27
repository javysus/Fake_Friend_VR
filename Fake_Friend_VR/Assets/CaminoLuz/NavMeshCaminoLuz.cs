using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCaminoLuz : MonoBehaviour
{
    public Transform objetivo;
    public Transform player;
    private NavMeshAgent agente;
    public bool llegar;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.SetDestination(objetivo.position);
    }

    public IEnumerator ActivarCaminoLuz()
    {
        if (!agente.pathPending)
        {
            if (agente.remainingDistance <= agente.stoppingDistance)
            {
                if (!agente.hasPath || agente.velocity.sqrMagnitude == 0f)
                {
                    yield return new WaitForSeconds(0.5f);
                    agente.GetComponent<TrailRenderer>().enabled = false;
                    agente.transform.position = player.position;
                    agente.GetComponent<TrailRenderer>().time = 0f;
                    yield return new WaitForSeconds(0.3f);
                    agente.GetComponent<TrailRenderer>().enabled = true;
                    agente.GetComponent<TrailRenderer>().time = 0.7f;
                }
            }
        }
    }

    public void ActualizarCamino(Transform nuevoObjetivo)
    {
        agente.SetDestination(nuevoObjetivo.position);
    }

    public void Update()
    {
        StartCoroutine(ActivarCaminoLuz());   
    }
}
