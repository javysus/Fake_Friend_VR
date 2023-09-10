using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS {
public class BesarJosefa : MonoBehaviour
{
    // Start is called before the first frame update
    Collider _collider;
    public GameObject Josefa;
    public GameObject DialogueControllerJosefa;
    void Start()
    {
        _collider = GetComponent<Collider>();
            Debug.Log("Holaholahola");
        //_collider.isTrigger = true;

        /*
        uri_get = "https://2073-200-124-49-206.ngrok-free.app/datossesionusuario?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;
        uri_update = "https://2073-200-124-49-206.ngrok-free.app/updatedatos?id_usuario=" + id_usuario + "&id_sustancia=" + id_sustancia;

        StartCoroutine(GetData_Coroutine());
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject game = other.gameObject;
        Debug.Log("Colision con el socket");
        Debug.Log("El objeto es " + other + "y" + game);
        if (game.tag == "besojo")
        {
            Debug.Log("Test Josefa colisiona");
            Josefa.GetComponent<Animator>().SetTrigger("besar_trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameObject game = other.gameObject;
        if (other.tag == "besojo")
        {
            Debug.Log("Test Josefa colisiona");
            Josefa.GetComponent<Animator>().SetTrigger("bailar_trigger");
            DialogueControllerJosefa.GetComponent<DialogueManagerJosefA>().fin_beso = false;
        }
    }
    }
}
