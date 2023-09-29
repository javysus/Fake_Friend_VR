using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrRestobar : MonoBehaviour
{
    public GameObject jugador;
    public GameObject irseButton;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            irseButton.SetActive(true);
        }
    }
}
