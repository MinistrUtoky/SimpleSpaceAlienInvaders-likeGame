using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject asteroidPrefab;

    void Start()
    {
        StartCoroutine(CloneEnemy());
        StartCoroutine(CloneAsteroid());
    }

    IEnumerator CloneEnemy()
    {
        while (true)
        {

            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
    IEnumerator CloneAsteroid()
    {
        while (true)
        {
            Instantiate(asteroidPrefab, new Vector3(9.9f, Random.Range(-6f, 6f), 0), Quaternion.identity);
            yield return new WaitForSeconds(7f);
        }
    }
}
