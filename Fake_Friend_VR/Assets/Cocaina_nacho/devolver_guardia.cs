using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devolver_guardia : MonoBehaviour
{
    public llevar_guardia guardia;
    public GameObject desmayo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si no estamos sosteniendo ningún objeto y el objeto es recogible
            guardia.personaje.transform.SetParent(null);
            guardia.script.enabled = true;
            guardia.MoverAlDestinoSiguiente();
            StartCoroutine(activar_desmayo());


            //personaje.GetComponent<Rigidbody>().isKinematic = true; // Hacer que el objeto no sea afectado por la física
        }

    }
    private IEnumerator activar_desmayo()
    {
        yield return new WaitForSeconds(5.0f); // Espera durante el tiempo especificado

        // Desactiva el objeto después del tiempo especificado
        desmayo.SetActive(true);
    }
}
