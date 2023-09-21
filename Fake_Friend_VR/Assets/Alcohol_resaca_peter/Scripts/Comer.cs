using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource eating;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Comida"))
        {
            Debug.Log("Entro el la comida");
            other.gameObject.SetActive(false);
            eating.Play();
        }
    }
}
