using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicEnemyBehavior : MonoBehaviour
{
    public bool isDead;
    public bool isWalking;

    // the player
    public Transform target;

    public GameObject healthDrop;

    public NavMeshAgent agent;
    Animator gnomeAnimator;

    public Slider healthBar;

    public GnomeScriptableObject gnomeProperties;

    public AudioClip gnomeDeadSFX;

    int health;

    // Start is called before the first frame update
    void Start()
    {
        // level manager initialization 
        GameObject.FindObjectOfType<LevelManager>().TrackSpawn();

        // nav mesh agent initializaiton
        agent = GetComponent<NavMeshAgent>();
        agent.speed = gnomeProperties.speed;
        agent.stoppingDistance = gnomeProperties.minDistance;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // gnome animator initialization 
        gnomeAnimator = GetComponentInChildren<Animator>();
        isWalking = false;

        // gnome health initialization 
        health = gnomeProperties.maxHealth;
        isDead = false;
        healthBar = GetComponentInChildren<Slider>();
        UpdateHealthBarUI();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        // Debug.Log(distance);
        var step = gnomeProperties.speed * Time.deltaTime;
        transform.LookAt(target);
        UpdateHealthBarUI();
        if (distance <= gnomeProperties.maxDistance && distance >= gnomeProperties.minDistance)
        {
            agent.SetDestination(target.position);
            gnomeAnimator.SetBool("isWalking", true);
            agent.speed = gnomeProperties.speed;
            // Debug.Log(agent.speed);
            // transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else 
        {
            gnomeAnimator.SetBool("isWalking", false);
            agent.speed = 0;
        }
        // Debug.Log("isWalking: " + isWalking);
        //gnomeAnimator.SetBool("isWalking", isWalking);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PlayerHealth.currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerHealth>().TakeDamage(gnomeProperties.damageAmount);
            // Debug.Log("Player hit!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gnomeProperties.maxDistance);
    }

    public void InstantKillGnome()
    {
        gnomeAnimator.SetTrigger("isDead");
        if (!isDead)
        {
            GameObject.FindObjectOfType<LevelManager>().TrackKill();
            AudioSource.PlayClipAtPoint(gnomeDeadSFX, gameObject.transform.position, 10f);
            Destroy(gameObject, 1f);
        }
        isDead = true;
    }

    public void TakeDamage(int damage)
    {
        // Debug.Log("health previous " + health);
        health -= damage;
        // Debug.Log("health left " + health);
        if (IsDead())
        {
            InstantKillGnome();
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    private void OnDestroy()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        Instantiate(healthDrop, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), transform.rotation);
    }

    private void UpdateHealthBarUI()
    {
        if (healthBar != null) {
            healthBar.value = (int)(((double)health / (double)gnomeProperties.maxHealth) * healthBar.maxValue);
            // Debug.Log("health: " + health);
            // Debug.Log("max health: " + gnomeProperties.maxHealth);
            // Debug.Log("max value: " + healthBar.maxValue);
            // Debug.Log(healthBar.value);
        }
    }
}
