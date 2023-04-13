using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GnomeScriptableObject", menuName = "gnome.ttv/GnomeScriptableObject", order = 0)]
public class GnomeScriptableObject : ScriptableObject {

    // the speed at which the enemy moves
    public float speed = 10f;

    // the max range of the enemy detection
    public float maxDistance = 30f;

    // the min range of enemy detection to prevent weird collisions
    public float minDistance = 0.75f;

    // amount of damage
    public int damageAmount = 10;

    // max health of the gnome 
    public int maxHealth = 10;

    void OnEnable() {

    }

    public void DamagePlayer(Collider other) {
        if (other.CompareTag("Player") && PlayerHealth.currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(damageAmount);
        }
    }

}

