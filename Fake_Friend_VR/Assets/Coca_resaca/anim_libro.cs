using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_libro : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public GameObject boton;
    public GameObject panel;
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void play()
    {
        animator.SetTrigger("leer");
        Debug.Log("ACTIVAR ANIMACION");
    }

    public void mostrar_panel()
    {
        Destroy(boton);
        panel.SetActive(true);
    }
}
