using UnityEngine;

public class HeadSync : MonoBehaviour
{
    public Transform head;
    public Transform ikHead;

    void LateUpdate()
    {
        // Sincronizar la posición y rotación del IKHead con la cabeza
        ikHead.position = head.position;
        ikHead.rotation = head.rotation;
    }
}