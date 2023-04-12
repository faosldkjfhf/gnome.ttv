using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunBullet : MonoBehaviour
{
    public int waterDamage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            Debug.Log(waterDamage);
            Destroy(gameObject);
            BasicEnemyBehavior enemyProperties = other.GetComponent<BasicEnemyBehavior>();
            enemyProperties.TakeDamage(waterDamage);
        }
    }
    
}
