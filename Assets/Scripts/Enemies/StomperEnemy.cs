using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperEnemy : Enemy
{
    public float speed;

    [SerializeField] GameObject stompEffect;

    bool isStomping = false;
    bool hasStomped = false;
    float stompPo;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stompPo = Random.Range(-9,1);
    }
    private void Update()
    {
        while (!isStomping)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
        if (!hasStomped && transform.position.y == stompPo)
        {
            Stomp();
        }
    }
    void Stomp()
    {
        isStomping = true;
        rb.useGravity = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(stompEffect, transform.position - Vector3.up * 0.5f, Quaternion.identity);
        isStomping = false;
    }
}
