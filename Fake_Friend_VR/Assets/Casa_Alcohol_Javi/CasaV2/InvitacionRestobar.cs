using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvitacionRestobar : MonoBehaviour
{
    public Material Material1;
    public GameObject ColliderPuerta;
    public GameObject caminoLuz;
    public void mensajeCony()
    {
        GetComponent<MeshRenderer>().material = Material1;
        ColliderPuerta.SetActive(true);
        caminoLuz.SetActive(false);
        caminoLuz.SetActive(true);
        caminoLuz.GetComponent<Animator>().ResetTrigger("Celular");
        caminoLuz.GetComponent<Animator>().SetTrigger("Restobar");
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
