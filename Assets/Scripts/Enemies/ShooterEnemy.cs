using System.Collections;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;
    [SerializeField] float projectileSpeed = 10f;
    private Transform plyr;
    private Coroutine shootingCoroutine;
    bool shooting = false;
    [SerializeField] float shootPos;

    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        GameObject plyrObject = GameObject.FindGameObjectWithTag("Player");
        if (plyrObject != null)
        {
            plyr = plyrObject.transform;
        }
        shootingCoroutine = StartCoroutine(ShootContinuously());
    }

    void Update()
    {
        if (plyr != null)
        {
            Vector3 direction = plyr.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
        if (transform.position.x >= shootPos)
        {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }
        else
        {
            if (!shooting)
            {
                shooting = true;
                if (shootingCoroutine == null)
                {
                    shootingCoroutine = StartCoroutine(ShootContinuously());
                }
            }
        }
    }
    IEnumerator ShootContinuously()
    {
        while (shooting)
        {
            Shoot();
            yield return new WaitForSeconds(2f);
        }
    }

    void Shoot()
    {
        if (plyr != null)
        {
            GameObject newProjectile = Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
            Vector3 direction = (plyr.position - shootingPoint.position).normalized;
            newProjectile.transform.forward = direction;

            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("PlayerProjectile"))
    //    {
    //        LoseLife(player.damage);
    //    }
    //}
}