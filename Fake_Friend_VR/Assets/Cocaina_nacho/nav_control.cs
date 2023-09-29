using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class nav_control : MonoBehaviour
{
    

    public List<Transform> puntosDeDestino; // Array de los puntos de destino
    public NavMeshAgent navMeshAgent;
    private int indiceDestinoActual = 0;
    public Animator animacion;
    public efectos_coca efectos;
    public Transform mirar_a;
    public Camera maincamara;
    public Camera disociacion;
    private bool flag=true;
    

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
        animacion = GetComponent<Animator>();
        animacion.SetTrigger("idle");

    }

    public void MoverAlDestinoSiguiente()
    {
        if (indiceDestinoActual < puntosDeDestino.Count)
        {
            navMeshAgent.SetDestination(puntosDeDestino[indiceDestinoActual].position);
            indiceDestinoActual++;
        }
    }

    private void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            
            animacion.ResetTrigger("start_walk");
            animacion.SetTrigger("idle");
            
            transform.LookAt(mirar_a);


        }
        if (indiceDestinoActual == 2)
        {
            //activar paranoia
            
            if (flag)
            {
                efectos.aumentar = true;
                flag = false;
                StartCoroutine(primer_cambio());
                StartCoroutine(segundo_cambio());
                Debug.Log("activar 2do efecto");
            }
            
        }
    }

    private IEnumerator primer_cambio()
    {
        yield return new WaitForSeconds(20.0f); // Espera durante el tiempo especificado

        // Desactiva el objeto después del tiempo especificado
        cambio_cam();
    }

    private IEnumerator segundo_cambio()
    {
        yield return new WaitForSeconds(25.0f); // Espera durante el tiempo especificado

        // Desactiva el objeto después del tiempo especificado
        volver_cam();
    }

    public void cambio_cam()
    {
        maincamara.depth = 0;
        disociacion.depth = 1;
    }

    public void volver_cam()
    {
        maincamara.depth = 1;
        disociacion.depth = 0;
    }
}
