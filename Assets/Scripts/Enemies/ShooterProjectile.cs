using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerManager playerManager))
        {
            playerManager.DecreaseHealth(5f);
        }
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("PlayerProjectile"))
        {
            GameObject explode = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Destroy(gameObject);
        }
    }
}