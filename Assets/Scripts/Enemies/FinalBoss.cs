using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;

public class FinalBoss : Enemy
{
    public bool bossActive = false;
    public float stopPos;

    public Transform stomperSpawn;
    public GameObject stomper;
    private void Start()
    {
        StartCoroutine(StomperSpawn());
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
    }
    IEnumerator StomperSpawn()
    {
        while (true)
        {
            if (bossActive)
            {
                SpawnStomper();
            }
            yield return new WaitForSeconds(7f);
        }
    }
    void SpawnStomper()
    {
        Instantiate(stomper, stomperSpawn);
    }
}
