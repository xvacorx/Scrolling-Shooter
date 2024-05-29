using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class FinalBoss : Enemy
{
    public bool bossActive = false;
    public float stopPos;

    public Transform stomperSpawn;
    public GameObject stomper;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shootingPoint;

    private Transform plyr;
    GameObject plyrObject;
    int counter;
    private void Start()
    {
        StartCoroutine(StomperSpawn());
        player = FindObjectOfType<PlayerManager>();
        plyrObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (bossActive)
        {
            if (transform.position.x >= stopPos)
            {
                transform.position += Vector3.left * 5f * Time.deltaTime;
            }

        }
        if (plyrObject != null)
        {
            plyr = plyrObject.transform;
        }
    }
    IEnumerator StomperSpawn()
    {
        while (true)
        {
            if (bossActive)
            {
                counter++;
                Shoot();
                if(counter % 5  == 0) { SpawnStomper(); }
            }
            yield return new WaitForSeconds(3f);
        }
    }
    void SpawnStomper()
    {
        Instantiate(stomper, stomperSpawn);
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
                rb.velocity = direction * 10;
            }
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            if(life % 5 == 0)
            {
                OnEnemyDefeated();
            }
        }
    }
}
