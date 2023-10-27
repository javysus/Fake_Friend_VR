using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcosadorScript : MonoBehaviour
{
    public Transform target;
    public bool llegada = false;
    public bool inTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 6f)
        {
            Debug.Log("At Destionation Acosador");
            llegada = true;
            transform.LookAt(target.position);
        } }
}
