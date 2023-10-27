using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhalarSocket : MonoBehaviour
{
    public AudioSource inhalar;
    private float tiempo_i;
    private float tiempo_f;
    private bool drogas = false;
    public AudioSource latidos;
    public AudioSource pitidos;
    public GameObject leftHandControllerFalso;
    public Transform leftHandController;
    public Controlador controlador;
    private bool efectos1 = true;
    private bool efectos2 = true;
    private bool efectos3 = true;
    public GameObject polvito;

    public GameObject blackScreen;
    public AudioSource sonidoInfarto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        tiempo_f = Time.time;

        if((tiempo_f - tiempo_i) >= 3f && drogas && efectos1)
        {
            //Latidos
            latidos.Play();
            pitidos.Play();

            efectos1 = false;
        }

        else if((tiempo_f - tiempo_i) >= 6f && drogas && efectos2)
        {
            //Disminucion del control izquierdo
            //leftHandControllerFalso.GetComponent<FollowObject>().enabled = true;
            controlador.leftHand.vrTarget = leftHandControllerFalso.transform;
            
            Debug.Log("Holi");

            efectos2 = false;
        }else if ((tiempo_f - tiempo_i) >= 15f && drogas && efectos3)
        {
            //Pantalla negra
            sonidoInfarto.Play();
            blackScreen.SetActive(true);
        
            efectos3 = false;
        }
}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entre al collider, pero aun no verifico pastillas");
        Debug.Log("Tag: " + other.tag);
        if (other.CompareTag("Mano")) //Que en realidad es polvo
        {
            //Se corta el tiempo
            //Reproducir sonido de inhalar
            Debug.Log("Estoy apunto de inhalar");
            inhalar.Play();
            GetComponent<SphereCollider>().enabled = false;

            //Desactivar polvo
            polvito.SetActive(false);


            //Comenzar a contar tiempo de droga
            tiempo_i = Time.time;

            drogas = true;
        }
    }
}
