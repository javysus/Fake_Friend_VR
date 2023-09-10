using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DS {
public class LogicaBesarJosefa : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Josefa;
    public GameObject DialogueControllerJosefa;
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
            Debug.Log("Hola,entre al beso");
            Josefa.GetComponent<Animator>().SetTrigger("besar_trigger");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,me sali del beso");
            Josefa.GetComponent<Animator>().SetTrigger("bailar_trigger");
            DialogueControllerJosefa.GetComponent<DialogueManagerJosefA>().fin_beso = true;
        }
    }
}
}