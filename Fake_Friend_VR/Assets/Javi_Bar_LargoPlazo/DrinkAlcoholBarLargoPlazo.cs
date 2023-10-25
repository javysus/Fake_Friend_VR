using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkAlcoholBarLargoPlazo : MonoBehaviour
{
    Collider _collider;
    float SavedTime = 0f;
    float DelayTime = 1f;
    float SavedCheckTime = 0f;
    float CheckTime = 30f;
    int id_usuario = 1;
    int id_sustancia = 1;
    string uri_get;
    string uri_update;

    //Objeto de camara Camara Offset
    public GameObject camara_efectos;
    public bool colisionVaso = false;
    public int vasos = 0;

    //Objetos para flujo de historia
    public GameObject espejo;
    public GameObject caminoEspejo;


    private bool terminarVaso =false;
    public GameObject sentarseButton;

    public float size = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vasos == 1 && !terminarVaso)
        {
            //Activar boton para pararse

            sentarseButton.SetActive(true);
            sentarseButton.LeanScale(new Vector3(size, size, size), 1f);
            terminarVaso = true;

            //Activar camino de luz
            caminoEspejo.SetActive(true);

            //Activar trigger de espejo
            espejo.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Test colision entrar " + other);
        GameObject game = other.gameObject;

        //Vaso de agua
        if (other.tag == "Vaso")
        {
            //Debug.Log("Test colisiona con vaso ");
            colisionVaso = true;
            game.GetComponent<AudioSource>().Play();
        }

    }

    void OnTriggerExit(Collider other)
    {
        //Vaso de agua
        GameObject game = other.gameObject;
        colisionVaso = false;

        if (other.tag == "Vaso")
        {
            colisionVaso = false;

        }

    }


}
