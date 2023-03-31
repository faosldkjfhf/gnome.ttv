using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
    public bool isDead;

    // the player
    public Transform player;

    // the speed at which the enemy moves
    public float speed = 2f;

    // the max range of the enemy detection
    public float maxDistance = 30f;

    // the min range of enemy detection to prevent weird collisions
    public float minDistance = 5f;

    // amount of damage
    public int damageAmount = 10;


    void Awake() {
        // if target isn't assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        isDead = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<LevelManager>().TrackSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.position);
        // Debug.Log(distance);
        var step = speed * Time.deltaTime;
        transform.LookAt(player);
        if (distance <= maxDistance && distance >= minDistance)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerHealth.currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(damageAmount);
            // Debug.Log("Player hit!");
        }
    }
}
