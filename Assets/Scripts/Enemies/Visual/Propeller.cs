using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float rotationSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed);
    }
}
