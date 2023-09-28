using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostrar_panel : MonoBehaviour
{
    public float range;
    public LayerMask capaplayer;
    bool look;
    public Transform player;//target position
    public AudioSource inhalar;
    public efectos_coca cont_gral;
    public flujo_historia flujo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        look = Physics.CheckSphere(transform.position, range, capaplayer);
        if (look)
        {
            inhalar.Play();
            Destroy(gameObject, 3.0f);
            cont_gral.iniciar = true;
            Invoke("sig_destino", 2.0f);
            //flujo.mover_destino();

        }
        else
        {
            
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void sig_destino()
    {
        flujo.mover_destino();
    }
}
