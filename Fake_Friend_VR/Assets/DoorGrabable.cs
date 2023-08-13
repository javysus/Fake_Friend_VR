using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorGrabable : XRGrabInteractable
{
    public Transform handler;
    public Rigidbody rb;

    public void EndGrab()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
        Drop();
    }

}
