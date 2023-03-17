using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
    }

    void SpawnEnemies() {
        Vector3 enemyPosition;

        enemyPosition.x = gameObject.transform.position.x;
        enemyPosition.y = gameObject.transform.position.y;
        enemyPosition.z = gameObject.transform.position.z;

        GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, transform.rotation)
            as GameObject;
        
        spawnedEnemy.transform.parent = gameObject.transform;
    }
}
