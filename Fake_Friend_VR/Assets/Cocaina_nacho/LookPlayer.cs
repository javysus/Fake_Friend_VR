using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public float range;
    public LayerMask capaplayer;
    bool look;
    public Transform player;//target position
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        look = Physics.CheckSphere(transform.position, range, capaplayer);
        if (look)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

    }

    /*
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position,rangoDeAlerta);
    }
    */

}