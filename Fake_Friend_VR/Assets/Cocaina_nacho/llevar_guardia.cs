using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class llevar_guardia : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject personaje;
    public List<Transform> puntosDeDestino; // Array de los puntos de destino
    public Transform objetoEnMovimiento;
    public NavMeshAgent navMeshAgent;
    private int indiceDestinoActual = 0;
    public movimiento_control script;
    private bool flag=true;
    private bool bandera = true;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        if (personaje == null && other.CompareTag("Player"))
        {
            // Si no estamos sosteniendo ningún objeto y el objeto es recogible

            personaje = other.gameObject;
            personaje.transform.SetParent(transform); // Hacer que el objeto sea hijo de la mano
            personaje.transform.localPosition = Vector3.zero; // Posicionar el objeto en la mano
            script = personaje.GetComponent<movimiento_control>();
            script.enabled = false;
            flag = false;
            MoverAlDestinoSiguiente();
            
            //personaje.GetComponent<Rigidbody>().isKinematic = true; // Hacer que el objeto no sea afectado por la física
        }
        
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
        if (objetoEnMovimiento != null && flag==true)
        {
            navMeshAgent.SetDestination(objetoEnMovimiento.position);
        }

        
    }

}
