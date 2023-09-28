using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class primera_interaccion : MonoBehaviour
{
    // Start is called before the first frame update
    public float range;
    bool look;
    public LayerMask capaplayer;
    public GameObject panel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        look = Physics.CheckSphere(transform.position, range, capaplayer);
        if (look)
        {
            panel.SetActive(true);
            


        }
        else
        {
            panel.SetActive(false);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    
}
