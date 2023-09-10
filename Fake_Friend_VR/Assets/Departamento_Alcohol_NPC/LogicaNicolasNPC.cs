using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaNicolasNPC : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject panelHablar;
    public GameObject dialogo;
    public GameObject jugador;
    public Transform Target;
    private Animator animador;
    public bool culturaChupistica = false;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
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
            animador = GetComponent<Animator>();
            //animador.SetTrigger("HablarCollider");
            panelHablar.LeanScale(Vector3.one, 0.5f);
            if (culturaChupistica)
            {
                dialogo.transform.LookAt(new Vector3(0f, Target.position.y, 0f));
            }
            else
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
            //animador.SetTrigger("HablarCollider");
            if (culturaChupistica)
            {
                dialogo.transform.LookAt(new Vector3(0f, Target.position.y, 0f));
            }
            else
            {
                transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));

            }//panelHablar.transform.LookAt(new Vector3(Target.position.x, panelHablar.transform.position.y, Target.position.z));
            //panelHablar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hola,me sali");
            panelHablar.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
            //panelHablar.SetActive(false);
        }
    }

    /*private IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / TicksPerSecond);

        while (True)
        {
            if (!Pause)
            {
                transform.Rotate(Vector3.up * RotationAmount);
            }

            yield return Wait;
        }


    }*/
}
