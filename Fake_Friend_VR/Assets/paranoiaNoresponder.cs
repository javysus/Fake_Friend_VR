using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paranoiaNoresponder : MonoBehaviour
{

    public GameObject dialogo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void noResponder()
    {
        dialogo.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
