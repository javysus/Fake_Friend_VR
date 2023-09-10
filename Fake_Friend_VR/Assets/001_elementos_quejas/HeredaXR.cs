using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class HeredaXR : ActionBasedContinuousMoveProvider
{
    // Nuevos campos personalizados
    public float customMoveSpeed = 3.0f;
    public float customRotationSpeed = 90.0f;
    //--------------
    public Animator animator;
    public bool dormir = true;
    public GameObject panelCama;
    public GameObject blackScreen;
    public GameObject camara_efectos;
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        
    }
    // Nueva propiedad personalizada
    public float CustomMoveSpeed
    {
        get { return customMoveSpeed; }
        set { customMoveSpeed = value; }
    }

    // Método personalizado para cambiar el movimiento
    public void ChangeMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    private IEnumerator WaitAndDoSomething()
    {
        Debug.Log("Esperando un momento...");
        //frozenPosition = transform.position;
        blackScreen.SetActive(true);
        ChangeMoveSpeed(0.0f); //congelar movimiento
        dormir=true;
        // Esperamos durante 2 segundos
        yield return new WaitForSeconds(5.0f);

        Debug.Log("Espera finalizada. Haciendo algo después del tiempo de espera.");
        animator.Play("despertar");
        blackScreen.SetActive(false);
        ChangeMoveSpeed(1.0f);
        camara_efectos.GetComponent<Volume>().enabled = true;
        audioSource.Play();

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cama") && dormir == false)
        {
            Debug.Log("colision con cama");
            panelCama.SetActive(true);
            //StartCoroutine(WaitAndDoSomething());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cama"))
        {
            panelCama.SetActive(false);
        }
    }

    public void Dormir()
    {
        panelCama.SetActive(false);
        StartCoroutine(WaitAndDoSomething());
    }
}