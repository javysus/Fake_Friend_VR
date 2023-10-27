using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
    public GameObject[] objetos;

    void Start()
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            Outline outline = objetos[i].AddComponent<Outline>();
            outline.enabled = true;
            objetos[i].GetComponent<Outline>().OutlineColor = Color.cyan;
            objetos[i].GetComponent<Outline>().OutlineWidth = 4.0f;
        }
    }
}

