using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float damage = 1f;
    public float attackSpeed = 1f;
    public float health = 100f;

    public void IncreaseDamage(float amount)
    {
        damage += amount;
        if (damage >= 10f) { damage = 10f; }
    }

    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed -= amount;
        if (attackSpeed <= 0.1f) { attackSpeed = 0.1f; }
    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        if (health >= 100) { health = 100; }
    }
}
