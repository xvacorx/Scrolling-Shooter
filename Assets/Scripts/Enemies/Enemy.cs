using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float startingLife;
    public float damage;

    float life;

    private void Start()
    {
        life = startingLife;
    }
    public void LoseLife(float hitDamage)
    {
        startingLife -= hitDamage;
        if(startingLife <= 0) { Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            PlayerManager player = GetComponent<PlayerManager>();
            LoseLife(player.damage);
            if(life <= 0) { Destroy(gameObject); }   
        }
    }
}