using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amnesia : MonoBehaviour
{
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public GameObject opcion;

    public IEnumerator interactuarChat()
    {
        yield return new WaitForSeconds(4);
        GetComponent<MeshRenderer>().material = Material2;
        opcion.SetActive(true);
    }

    public IEnumerator interactuarChat2()
    {
        GetComponent<MeshRenderer>().material = Material3;
        yield return new WaitForSeconds(4);
        GetComponent<MeshRenderer>().material = Material4;
    }
    public void chatAmigos()
    {
        GetComponent<MeshRenderer>().material = Material1;
        StartCoroutine(interactuarChat());
    }

    public void escogerDecision()
    {
        opcion.SetActive(false);
        StartCoroutine(interactuarChat2());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
