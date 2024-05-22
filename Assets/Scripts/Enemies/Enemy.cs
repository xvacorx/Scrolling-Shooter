using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float life;
    public float damage;

    private PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        if (player == null)
        {
            Debug.LogError("PlayerManager no encontrado en la escena.");
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            if (player != null)
            {
                LoseLife(player.damage);
            }
        }
    }
}