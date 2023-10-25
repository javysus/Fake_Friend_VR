using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamiControllerAlcoholica : MonoBehaviour
{
    public GameObject head;
    public GameObject IKHead;
    public GameObject rightHand;
    public GameObject leftHand;
    public PlayerSit ps;
    // Start is called before the fipublic Transform head;
    void Start()
    {
        SitDown();
    }

    public void Vomitar()
    {
        ps.Vomitar();
    }

    void SitDown()
    {
        //GetComponent<Animator>().SetTrigger("sentarse");
        ps.SitDown();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
