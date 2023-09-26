using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvitacionRestobar : MonoBehaviour
{
    public Material Material1;

    public void mensajeCony()
    {
        GetComponent<MeshRenderer>().material = Material1;
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
