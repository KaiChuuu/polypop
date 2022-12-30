using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class RotateModels : MonoBehaviour
{
    public float rotationSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed, Space.Self);
    }
}
