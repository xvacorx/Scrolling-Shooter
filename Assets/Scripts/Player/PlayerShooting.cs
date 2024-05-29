using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;

    private Coroutine shootingCoroutine;

    public bool shootingEnabled = false;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        shootingCoroutine = StartCoroutine(ShootContinuously());
    }

    void OnDisable()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    IEnumerator ShootContinuously()
    {
        while (true)

        {
            if (shootingEnabled)
            {
                Shoot();
            }
            yield return new WaitForSeconds(playerManager.attackSpeed);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);
    }
}
