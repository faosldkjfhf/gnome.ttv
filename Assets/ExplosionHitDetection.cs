using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHitDetection : MonoBehaviour
{
    public int damage = 15;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<BasicEnemyBehavior>().TakeDamage(damage);
        }
    }
}
