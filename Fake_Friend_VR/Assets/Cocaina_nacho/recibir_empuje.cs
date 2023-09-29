using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recibir_empuje : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animacion;
    public llevar_guardia guardia;
    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            animacion.ResetTrigger("idle");
            animacion.SetTrigger("empuje");
            guardia.enabled = true;

        }

    }
}
