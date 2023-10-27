using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empujar_ammigo : MonoBehaviour
{
    public Animator animacion;
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
            animacion.ResetTrigger("bailar");
            animacion.SetTrigger("empuje");
            

        }

    }
}
