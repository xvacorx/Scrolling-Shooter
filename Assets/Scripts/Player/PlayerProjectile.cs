using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}