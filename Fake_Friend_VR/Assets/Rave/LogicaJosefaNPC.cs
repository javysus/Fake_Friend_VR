using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaJosefaNPC : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject panelHablar;
    public Transform Target;
    public GameObject Josefa;

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
            Debug.Log("Hola,entre");

            panelHablar.LeanScale(Vector3.one, 0.5f);
            Josefa.transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Josefa.transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,me sali");
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();

        }
    }

}