using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachFood : MonoBehaviour
{
    public Transform tenedor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tenedor"))
        {
            Debug.Log("Entro el tenedors");
            transform.parent = tenedor;
        }
    }
}
