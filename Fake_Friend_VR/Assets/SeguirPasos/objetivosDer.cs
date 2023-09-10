using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivosDer : MonoBehaviour
{
    public int numDeObjetivos;
    public GameObject objder1;
    public GameObject objder2;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = 4;
        objder1.SetActive(true);
        objder2.SetActive(false);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numDeObjetivos==0)
        {
            objder1.SetActive(false);
            objder2.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "ObjetivoDer")&& (numDeObjetivos%2 == 0))
        {
            objder1.SetActive(false);
            objder2.SetActive(true);
            numDeObjetivos--;
            if (numDeObjetivos<=0)
            {
                Debug.Log("Fin baile der");
            }
            
        }
        else if ((col.gameObject.tag == "ObjetivoDer")&& (numDeObjetivos%2 != 0))
        {
            numDeObjetivos--;
            objder1.SetActive(true);
            objder2.SetActive(false);
        }
    }
}
