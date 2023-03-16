using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        // if target isn't assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.position);
        // Debug.Log(distance);
        var step = speed * Time.deltaTime;
        if (distance <= maxDistance && distance >= minDistance)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }

    public void DealDamage(int damage)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(damageAmount);
            Debug.Log("Player hit!");
        }
    }
}
