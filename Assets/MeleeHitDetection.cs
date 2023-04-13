using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitDetection : MonoBehaviour
{
    public MeleeWeaponController mwc;
    public GameObject hitEffect;
    public AudioClip gnomeDeadSFX;
    public int meleeDamage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && mwc.isAttacking)
        {
            Debug.Log("melee hit on enemy");
            // Instantiate(hitEffect, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
            BasicEnemyBehavior enemyProperties = other.GetComponent<BasicEnemyBehavior>();
            enemyProperties.TakeDamage(meleeDamage);
        }
    }
}
