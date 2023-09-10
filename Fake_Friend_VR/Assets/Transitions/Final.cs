using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FinalJuego()
    {
        //Play animation
        transition.SetTrigger("Start");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
