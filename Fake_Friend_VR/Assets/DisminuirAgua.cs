using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisminuirAgua : MonoBehaviour
{
    Renderer myRender;
    public float nivel = 1f;
    // Start is called before the first frame update
    public GameObject ObjAgua;
    void Start()
    {
        myRender = ObjAgua.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.up, transform.forward) <= 90f)
        {
            myRender.material.SetFloat("_Fill", (nivel - 0.02f));
        }
    }
}
