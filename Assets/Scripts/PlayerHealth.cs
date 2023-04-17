using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    int startingHealth = 100;
    Transform checkpoint;
    public static int currentHealth;

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

    public void TakeHealth(int health)
    {
        if (currentHealth < startingHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth + health, 0, startingHealth);
            healthSlider.value = currentHealth;
        }
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
            currentHealth = 0;
            healthSlider.value = currentHealth;
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
