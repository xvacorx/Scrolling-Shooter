using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float life;
    public float damage;

    public PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            LoseLife(player.damage);
        }
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerManager playerManager))
        {
            playerManager.DecreaseHealth(damage);
            Despawn();
        }
    }
    public void LoseLife(float hitDamage)
    {
        life -= hitDamage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Despawn()
    {
        Destroy(gameObject);
    }
}