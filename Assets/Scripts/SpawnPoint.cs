using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 5;
    public float randomRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
    }

    void SpawnEnemies() {
        if (GameObject.FindObjectOfType<LevelManager>().ShouldSpawnMore()) {
            Vector3 enemyPosition;

            enemyPosition.x = gameObject.transform.position.x + Random.Range(-randomRange, randomRange);
            enemyPosition.y = gameObject.transform.position.y;
            enemyPosition.z = gameObject.transform.position.z + + Random.Range(-randomRange, randomRange);;

            GameObject spawnedEnemy = Instantiate(enemyPrefab, enemyPosition, transform.rotation)
                as GameObject;
            
            spawnedEnemy.transform.parent = gameObject.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, randomRange);
    }

}
