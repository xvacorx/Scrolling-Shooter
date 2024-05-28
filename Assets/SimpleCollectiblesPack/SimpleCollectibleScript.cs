using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollectibleScript : MonoBehaviour
{
	public float rotationSpeed;
	void Update()
	{

		transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}
}