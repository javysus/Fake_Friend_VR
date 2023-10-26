using GLTF.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_papel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject contacto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mano"))
        {
            contacto.SetActive(true);

        }

    }
}
