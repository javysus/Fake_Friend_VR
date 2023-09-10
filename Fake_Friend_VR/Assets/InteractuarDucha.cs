using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarDucha : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelDuchaInteractuar;
    public GameObject panelDucha;
    public GameObject jugador;

    float TiempoMensaje = 0f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("colision con player");
            panelDuchaInteractuar.SetActive(true);
            //StartCoroutine(WaitAndDoSomething());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelDuchaInteractuar.SetActive(false);
        }
    }

    public void Ducharse()
    {
        panelDuchaInteractuar.SetActive(false);
        panelDucha.SetActive(true);
        TiempoMensaje = Time.time;
    }

    void Update()
    {
        if ((Time.time - TiempoMensaje) > 5.0f)
        {
            panelDucha.SetActive(false);
        }
    }
}
