using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MareosManejar : MonoBehaviour
{
    [SerializeField]
    float frequency = 1;
    [SerializeField]
    public Vector3 maximumAngularShake = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1, 0, 0) * 0.1f;

        transform.localPosition = new Vector3(
            (Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.1f,
            (Mathf.PerlinNoise(1, Time.time) * 2 - 1) * 0.1f,
            (Mathf.PerlinNoise(2, Time.time) * 2 - 1) * 0.1f
        );
        transform.localRotation = Quaternion.Euler(new Vector3(
            maximumAngularShake.x * (Mathf.PerlinNoise(3, Time.time * frequency) * 2 - 1),
            maximumAngularShake.y * (Mathf.PerlinNoise(4, Time.time * frequency) * 2 - 1),
            maximumAngularShake.z * (Mathf.PerlinNoise(5, Time.time * frequency) * 2 - 1)
        ));
    }
}
