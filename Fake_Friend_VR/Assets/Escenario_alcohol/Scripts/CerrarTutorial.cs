using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarTutorial : MonoBehaviour
{
    public void Cerrar(GameObject tutorial)
    {
        tutorial.SetActive(false);
    }
}
