using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspejoTrigger : MonoBehaviour
{
    public GameObject caminoEspejo;
    public GameObject caminoToilet;
    public GameObject toilet;
    public GameObject dialogo;
    public float size = 0.005f;
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
            //Desactivar camino porque ya llego
            caminoEspejo.SetActive(false);

            //Activar dialogo
            dialogo.SetActive(true);
            dialogo.LeanScale(new Vector3(size, size, size), 1f);

            //Activar nuevo camino de luz
            caminoToilet.SetActive(true);

            //Activar trigger de banio
            toilet.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Desactivar dialogo
            dialogo.LeanScale(Vector3.zero, 1f);
            dialogo.SetActive(false);

            this.enabled = false;
        }
    }
}
