using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanderEnemy : Enemy
{
    public float speed;
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= -15)
        {
            Despawn();
        }
    }
}