using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float life;
    public float damage;

    public PlayerManager player;

    public GameObject[] powerUps;
    float dropChance = 0.3f;

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
            OnEnemyDefeated();
            Destroy(gameObject);
        }
    }
    public void Despawn()
    {
        Destroy(gameObject);
    }
    public void OnEnemyDefeated()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= dropChance)
        {
            int powerUpIndex = Random.Range(0, powerUps.Length);
            GameObject selectedPowerUp = powerUps[powerUpIndex];

            Instantiate(selectedPowerUp, transform.position, Quaternion.identity);
        }
    }
}