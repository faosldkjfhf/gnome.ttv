using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GnomeScriptableObject", menuName = "gnome.ttv/GnomeScriptableObject", order = 0)]
public class GnomeScriptableObject : ScriptableObject {

    // the target that this gnome follows
    public Transform target;

    // the speed at which the enemy moves
    public float speed = 10f;

    // the max range of the enemy detection
    public float maxDistance = 30f;

    // the min range of enemy detection to prevent weird collisions
    public float minDistance = 0.75f;

    // amount of damage
    public int damageAmount = 10;

    // health of the gnome 
    public int health = 10;

    void OnEnable() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void TakeDamage(int damage) {
        health -= damage;
    }

    public bool IsDead() {
        return health <= 0;
    }

    public void DamagePlayer(Collider other) {
        if (other.CompareTag("Player") && PlayerHealth.currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(damageAmount);
        }
    }

}

