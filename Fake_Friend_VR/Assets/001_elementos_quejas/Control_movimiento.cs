using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_movimiento : MonoBehaviour
{
    public HeredaXR heredaXR;
    public Animator animator;
    public GameObject panelCama;
    public bool dormir = true;
    public GameObject blackScreen;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        heredaXR = GetComponent<HeredaXR>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndDoSomething()
    {
        Debug.Log("Esperando un momento...");
        //frozenPosition = transform.position;
        blackScreen.SetActive(true);
        
        dormir=true;
        // Esperamos durante 2 segundos
        yield return new WaitForSeconds(5.0f);

        Debug.Log("Espera finalizada. Haciendo algo después del tiempo de espera.");
        animator.Play("despertar");
        blackScreen.SetActive(false);
        //transform.position=frozenPosition;
        //moveSpeed = 1.0f;
        //velocidadMovimiento=3.0f;
        audioSource.Play();
    }
    

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("cama") && dormir==false)
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
