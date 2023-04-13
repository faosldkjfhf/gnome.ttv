using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyBehavior : MonoBehaviour
{
    public GnomeScriptableObject gnomeProperties;
    public AudioClip gnomeDeadSFX;
    public Transform target;



    public bool isDead;
    public bool isWalking;
    int health;
    

    // // the player
    // public Transform player;

    public NavMeshAgent agent;
    Animator gnomeAnimator;

    void Awake() {
        isDead = false;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = gnomeProperties.speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<LevelManager>().TrackSpawn();
        agent.stoppingDistance = gnomeProperties.minDistance;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        gnomeAnimator = GetComponent<Animator>();
        isWalking = false;
        health = gnomeProperties.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        // Debug.Log(distance);
        var step = gnomeProperties.speed * Time.deltaTime;
        transform.LookAt(target);
        if (distance <= gnomeProperties.maxDistance && distance >= gnomeProperties.minDistance)
        {
            // Debug.Log(isWalking);
            agent.SetDestination(target.position);
            isWalking = true;
            gnomeAnimator.SetBool("isWalking", true);
            // transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else 
        {
            isWalking = false;
            gnomeAnimator.SetBool("isWalking", false);
        }
        // Debug.Log("isWalking: " + isWalking);

    }

    private void OnTriggerEnter(Collider other)
    {
        gnomeProperties.DamagePlayer(other);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gnomeProperties.maxDistance);
    }

    public void InstantKillGnome() {
        gnomeAnimator.SetTrigger("isDead");
        if (!isDead)
        {
            GameObject.FindObjectOfType<LevelManager>().TrackKill();
            AudioSource.PlayClipAtPoint(gnomeDeadSFX, gameObject.transform.position, 10f);
            Destroy(gameObject, 1f);
        }
        isDead = true;
    }

    public void TakeDamage(int damage) {
        // Debug.Log("health previous " + health);
        health -= damage;
        // Debug.Log("health left " + health);
        if (IsDead()) {
            InstantKillGnome();
        }
    }

    public bool IsDead() {
        return health <= 0;
    }

    private void OnDestroy()
    {
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
