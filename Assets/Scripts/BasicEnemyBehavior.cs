using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyBehavior : MonoBehaviour
{
    public bool isDead;
    public bool isWalking;

    // the player
    public Transform player;

    // the speed at which the enemy moves
    public float speed = 10f;

    // the max range of the enemy detection
    public float maxDistance = 30f;

    // the min range of enemy detection to prevent weird collisions
    public float minDistance = 0.75f;

    // amount of damage
    public int damageAmount = 10;

    public NavMeshAgent agent;
    Animator gnomeAnimator;

    void Awake() {
        // if target isn't assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        isDead = false;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<LevelManager>().TrackSpawn();
        agent.stoppingDistance = minDistance;

        gnomeAnimator = GetComponentInChildren<Animator>();
        isWalking = false;
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
            agent.SetDestination(player.position);
            gnomeAnimator.SetBool("isWalking", true);
            // transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else 
        {
            gnomeAnimator.SetBool("isWalking", false);
            speed = 0;
        }
        Debug.Log("isWalking: " + isWalking);
        //gnomeAnimator.SetBool("isWalking", isWalking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerHealth.currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(damageAmount);
            // Debug.Log("Player hit!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
