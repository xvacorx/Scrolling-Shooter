using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    [SerializeField] GameObject effect;
    public abstract void ApplyPowerUp(GameObject player);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
            GameObject effectInstance = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(effectInstance, 1f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        transform.Translate(Vector3.left * 5 * Time.deltaTime);
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}