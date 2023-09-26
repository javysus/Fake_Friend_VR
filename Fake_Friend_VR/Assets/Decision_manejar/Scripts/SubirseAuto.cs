using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirseAuto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PanelSubirse;
    public GameObject PanelNegro;
    public GameObject caminoLuz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelSubirse.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PanelSubirse.SetActive(false);
        }
    }

    public void Subirse()
    {
        PanelSubirse.SetActive(false);
        PanelNegro.SetActive(true);
        GetComponent<AudioSource>().Play();
        caminoLuz.SetActive(false);
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
