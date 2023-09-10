using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaLuisNPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelHablar;
    public GameObject panelHablar2;
    public GameObject panelHablar3;
    public Transform Target;
    public bool dialogo0 = true;
    public bool dialogo1 = false;
    public bool dialogo2 = false;
    public bool accion = false;
    private Animator animador;

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
            if (dialogo1)
            {
                panelHablar2.SetActive(true);
                panelHablar2.LeanScale(Vector3.one, 0.5f);
                
            }
            else if (dialogo2)
            {
                panelHablar3.SetActive(true);
                panelHablar3.LeanScale(Vector3.one, 0.5f);
            }
            else if(dialogo0)
            {
                Debug.Log("Hola,entre me estoy activando jaja lol");
                animador = GetComponent<Animator>();
                panelHablar.LeanScale(Vector3.one, 0.5f);
              
            }
            if (!accion)
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            animador = GetComponent<Animator>();
            transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
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
