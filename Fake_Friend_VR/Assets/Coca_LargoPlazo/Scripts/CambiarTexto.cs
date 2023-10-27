using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarTexto : MonoBehaviour
{
    public void CambiarObjetivo(string objetivo)
    {
        GetComponent<Text>().text = objetivo;
    }
}
