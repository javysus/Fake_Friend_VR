using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class poner_musica : MonoBehaviour
{
    public GameObject panel_musica;
    private AudioSource audioSource; // Referencia al componente AudioSource.
    public GameObject jugador;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtén la referencia al AudioSource en el mismo GameObject.
        panel_musica.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            panel_musica.SetActive(true);
            Debug.Log("colision con mp3 detectada!");
             // Reproduce el audio si no está reproduciéndose.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel_musica.SetActive(false);
            Debug.Log("colision con mp3 salida");
            // Reproduce el audio si no está reproduciéndose.
        }
    }

    public void play(){
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
