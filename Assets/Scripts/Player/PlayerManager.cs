using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float damage = 1f;
    public float attackSpeed = 1f;
    public float health = 100f;

    GameManager manager;
    public GameObject explode;

    public Slider lifeSlider;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        lifeSlider.value = health;
    }
    public void IncreaseDamage(float amount)
    {
        damage += amount;
        if (damage >= 10f) { damage = 10f; }
    }
    public void DecreaseDamage(float amount)
    {
        damage -= amount;
        if (damage <= 1f) { damage = 10f; }
    }
    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed -= amount;
        if (attackSpeed <= 0.1f) { attackSpeed = 0.1f; }
    }
    public void DecreaseAttackSpeed(float amount)
    {
        attackSpeed += amount;
        if (attackSpeed >= 1f) { attackSpeed = 1f; }
    }
    public void IncreaseHealth(float amount)
    {
        health += amount;
        if (health >= 100) { health = 100; }
    }
    public void DecreaseHealth(float amount)
    {
        health -= amount;
        if (health <= 0) { health = 0; manager.GameOver(); Destroy(gameObject); Instantiate(explode, transform.position, Quaternion.identity); }
    }
}
