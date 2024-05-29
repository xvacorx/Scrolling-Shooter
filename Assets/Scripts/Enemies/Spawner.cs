using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawnerActive = true;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;

    private float probabilityEnemy1 = 0.4f;
    private float probabilityEnemy2 = 0.25f;
    //private float probabilityEnemy3 = 0.35f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (spawnerActive)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(2f);
        }

    }
    void SpawnEnemy()
    {
        float randomValue = Random.value;

        if (randomValue < probabilityEnemy1)
        {
            Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
        }
        else if (randomValue < probabilityEnemy1 + probabilityEnemy2)
        {
            Instantiate(enemy2, spawnPoint2.position, spawnPoint2.rotation);
        }
        else
        {
            Instantiate(enemy3, spawnPoint3.position, spawnPoint3.rotation);
        }
    }
}
