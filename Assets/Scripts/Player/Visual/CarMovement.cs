using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform[] wheels;
    public float rotationSpeed = 360f;
    void Update()
    {
        RotateWheels();
    }

    void RotateWheels()
    {
        float rotationAngle = rotationSpeed * Time.deltaTime;
        foreach (Transform wheel in wheels)
        {
            wheel.Rotate(Vector3.right, rotationAngle);
        }
    }
}
