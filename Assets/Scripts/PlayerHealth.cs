using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    int startingHealth = 100;
    Transform checkpoint;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").transform;
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            PlayerDies();
        }
    }

    void PlayerDies()
    {
        Debug.Log("Player died");
        GameObject.FindObjectOfType<LevelManager>().LevelLost();
        // should restart the from the last checkpoint
    }
}
