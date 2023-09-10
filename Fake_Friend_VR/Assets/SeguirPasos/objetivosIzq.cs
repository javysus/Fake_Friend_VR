using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivosIzq : MonoBehaviour
{
    public int numDeObjetivos1;
    public GameObject objizq1;
    public GameObject objizq2;
    public GameObject Luis;
    public GameObject NextController;
    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos1 = 4;
        objizq1.SetActive(true);
        objizq2.SetActive(false);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numDeObjetivos1==0)
        {
            objizq1.SetActive(false);
            objizq2.SetActive(false);

            //Fin del juego
            Debug.Log("Se activa boton de Luis");
            Luis.GetComponent<LogicaLuisNPC>().dialogo2 = true;
            NextController.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "ObjetivoIzq") && (numDeObjetivos1%2 == 0))
        {
            objizq1.SetActive(false);
            objizq2.SetActive(true);
            numDeObjetivos1--;
            if (numDeObjetivos1<=0)
            {
                Debug.Log("Fin baile izq");
            }
            
        }
        else if ((col.gameObject.tag == "ObjetivoIzq") && (numDeObjetivos1%2 != 0))
        {
            objizq1.SetActive(true);
            objizq2.SetActive(false);
            numDeObjetivos1--;
            if (numDeObjetivos1<=0)
            {
                Debug.Log("Fin baile izq");
            }
            
        }
    }
}
