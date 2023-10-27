using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrinkAlcoholCinematica : MonoBehaviour
{
    Collider _collider;
    float SavedTime = 0f;
    float DelayTime = 1f;
    float SavedCheckTime = 0f;
    float CheckTime = 30f;
    int id_usuario = 1;
    int id_sustancia = 1;
    public GameObject Vaso1;
    public GameObject Vaso2;
    public GameObject Vaso3;
    public GameObject blackScreen1;
    public GameObject blackScreen2;
    public GameObject DLight;
    public Text text;

    //Objeto de camara Camara Offset
    public GameObject camara_efectos;
    public bool colisionVaso = false;
    public int vasos = 0;

    //Objetos para flujo de historia
    public GameObject espejo;
    public GameObject caminoEspejo;


    private bool terminarVaso = false;
    public GameObject sentarseButton;

    public float size = 0.01f;
    // Start is called before the first frame update
    public IEnumerator primerVaso()
    {
        blackScreen1.SetActive(true);
        Vaso1.SetActive(false);
        DLight.SetActive(false);
        Vaso2.SetActive(true);
        yield return new WaitForSeconds(3);
        blackScreen1.SetActive(false);
    }
    public IEnumerator segundoVaso()
    {
        blackScreen2.SetActive(true);
        text.text = "2 semanas despues";
        Vaso2.SetActive(false);
        DLight.SetActive(true);
        Vaso3.SetActive(true);
        yield return new WaitForSeconds(3);
        blackScreen2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (vasos == 1 && !terminarVaso)
        {
            StartCoroutine(primerVaso());
        }
        else if (vasos == 2 && !terminarVaso)
        {
            StartCoroutine(segundoVaso());
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
