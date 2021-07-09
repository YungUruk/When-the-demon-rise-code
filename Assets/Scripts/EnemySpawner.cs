using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public float SpawnRate;
    public int count=0;

    void Start()
    {
        StartCoroutine(SpawnTestEnemy());
    }
    IEnumerator SpawnTestEnemy()
    {
        if (count < 2)
        {
            Instantiate(Enemies[0], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
            StartCoroutine(SpawnTestEnemy());
            count += 1;
        }

    }
}
