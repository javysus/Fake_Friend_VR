using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoneMesh : MonoBehaviour
{
    public Transform newArmature;
    public string rootBoneName = "Hips";
    public bool resetPose = false;
    public bool PressToReassign;

    void Update()
    {
        if (PressToReassign)
        {
            Reassign();
        }
        PressToReassign = false;
    }

    // [ContextMenu("Reassign Bones")]
    public void Reassign()
    {
        if (newArmature == null)
        {
            Debug.Log("No new armature assigned");
            return;
        }

        if (newArmature.Find(rootBoneName) == null)
        {
            Debug.Log("Root bone not found");
            return;
        }

        Debug.Log("Reassingning bones");
        SkinnedMeshRenderer rend = gameObject.GetComponent<SkinnedMeshRenderer>();
        Transform[] bones = rend.bones;

        rend.rootBone = newArmature.Find(rootBoneName);

        Transform[] children = newArmature.GetComponentsInChildren<Transform>();

        for (int i = 0; i < bones.Length; i++)
        {
            for (int a = 0; a < children.Length; a++)
            {
                if (bones[i] != null && children[a] != null && bones[i].name == children[a].name)
                {
                    if (resetPose)
                    {
                        children[a].transform.localPosition = bones[i].transform.localPosition;
                        children[a].transform.localRotation = bones[i].transform.localRotation;
                        children[a].transform.localScale = bones[i].transform.localScale;
                    }
                    bones[i] = children[a];
                    break;
                }
            }
        }
        rend.bones = bones;
    }
}
