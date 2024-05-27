using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperEnemy : Enemy
{
    public float speed;
    [SerializeField] GameObject stompExplosion;

    bool isStomping = false;
    bool hasStomped = false;
    int stompPos;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stompPos = Random.Range(0, 4);
    }

    private void Update()
    {
        if (!isStomping)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (!hasStomped && transform.position.x <= -stompPos && !isStomping)
        {
            Stomp();
        }
        if (transform.position.x <= -15)
        {
            Despawn();
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject explosion = Instantiate(stompExplosion, contact.point, Quaternion.identity);
        }
        base.OnCollisionEnter(collision);
        isStomping = false;
    }

    private void Stomp()
    {
        rb.useGravity = true;
        isStomping = true;
        hasStomped = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            LoseLife(player.damage);
        }
    }
}
