using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTimbre : MonoBehaviour
{
    private AudioSource audioSource;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public bool estarCerca;
    public GameObject panel_timbre;
    public GameObject Josefa;
    // Start is called before the first frame update
    void Start()
    {
        panel_timbre.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        estarCerca = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);
        if (estarCerca == true)
        {
            Debug.Log("Dentro del rango del timbre");
            panel_timbre.SetActive(true);
        }
        else
        {
            panel_timbre.SetActive(false);
        }
    }

    public void play_timbre()
    {
        audioSource.Play();
        //Josefa.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
