using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemyBehavior : MonoBehaviour
{
    public GnomeScriptableObject gnomeProperties;
    public AudioClip gnomeDeadSFX;

    bool isDead;
    bool isWalking;

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

        gnomeAnimator = GetComponent<Animator>();
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, gnomeProperties.target.position);
        // Debug.Log(distance);
        var step = gnomeProperties.speed * Time.deltaTime;
        transform.LookAt(gnomeProperties.target);
        if (distance <= gnomeProperties.maxDistance && distance >= gnomeProperties.minDistance)
        {
            agent.SetDestination(gnomeProperties.target.position);
            isWalking = true;
            gnomeAnimator.SetBool("isWalking", true);
            // transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        else 
        {
            isWalking = false;
            gnomeAnimator.SetBool("isWalking", false);
        }
        Debug.Log("isWalking: " + isWalking);

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
        isDead = true;
        GameObject.FindObjectOfType<LevelManager>().TrackKill();
        AudioSource.PlayClipAtPoint(gnomeDeadSFX, collision.gameObject.transform.position, 10f);
        Destroy(gameObject, 1f);
    }

    public void TakeDamage(int damage) {
        gnomeProperties.TakeDamage(damage);
        if (gnomeProperties.IsDead()) {
            InstantKillGnome();
        }
    }
}
