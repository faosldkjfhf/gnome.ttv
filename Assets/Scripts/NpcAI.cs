using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class NpcAI : MonoBehaviour
{
    public enum FSMStates
    {
        Idle,
        Walking,
        Talking
    }

    public Transform player;
    public float talkingDistance = 5f;
    public GameObject[] wanderPoints;
    public float walkingSpeed = 3.5f;
    public AudioClip speech;
    public TextMeshProUGUI interactive;
    public float volume = 0.5f;

    private FSMStates currentState;
    private Animator anim;
    private Vector3 nextDestination;
    private int currentDestinationIndex;
    private NavMeshAgent agent;
    private float distanceToPlayer;
    private bool isTalking;
    private float elapsedTime;
    private bool alreadyEnded = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // wanderPoints = GameObject.FindGameObjectsWithTag("WanderPoint");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isTalking = false;
        currentDestinationIndex = 0;
        currentState = FSMStates.Walking;
        FindNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        switch(currentState)
        {
            case FSMStates.Walking: 
                UpdateWalkingState();
                break;
            case FSMStates.Talking:
                UpdateTalkingState();
                break;
        }

        elapsedTime += Time.deltaTime;
    }

    /*
     * Wanders between given wanderPoints
     */
    void UpdateWalkingState()
    {
        // print("Patrolling");

        // print(currentDestinationIndex);

        agent.stoppingDistance = 0;

        agent.speed = walkingSpeed;

        anim.SetInteger("animState", 1);
        if (LevelManager.isGameOver)
        {
            nextDestination = player.position;
            agent.stoppingDistance = talkingDistance;
        }
        else if (Vector3.Distance(transform.position, nextDestination) < 5)
        {
            FindNextPoint();
        }

        if (distanceToPlayer <= talkingDistance)
        {
            interactive.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentState = FSMStates.Talking;
            }

        }
        else
        {
            interactive.enabled = false;
        }

        FaceTarget(nextDestination);

        agent.SetDestination(nextDestination);
    }

    /*
     * Random speech while the player is in distance
     */
    void UpdateTalkingState()
    {
        // print("Talking");

        interactive.enabled = false;

        agent.speed = 0;
        agent.stoppingDistance = 0;

        if (distanceToPlayer > talkingDistance)
        {
            currentState = FSMStates.Walking;
        }

        FaceTarget(player.transform.position);

        if (!isTalking)
        {
            if (!LevelManager.isGameOver)
            {
                elapsedTime = 0f;
                anim.SetInteger("animState", 2);
                AudioSource.PlayClipAtPoint(speech, transform.position, volume);
                isTalking = true;
            }
            else
            {
                if (!alreadyEnded)
                {
                    GameObject.FindObjectOfType<LevelManager>().LevelBeat();
                    alreadyEnded = true;
                }
            }
        }

        if (isTalking == true && elapsedTime >= speech.length)
        {
            elapsedTime = 0f;
            isTalking = false;
        }


    }

    /**
     * Turns this object to face the given target
     */
    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;

        directionToTarget.y = 0;

        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            10 * Time.deltaTime
        );
    }

    /*
     * Finds the next point for this object to walk to
     */
    void FindNextPoint()
    {
        nextDestination = wanderPoints[currentDestinationIndex].transform.position;

        currentDestinationIndex = (currentDestinationIndex + 1) % wanderPoints.Length;

        // Debug.Log(currentDestinationIndex);

        agent.SetDestination(nextDestination);
    }


     /*
      * Displays the talking distance of this object
      */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, talkingDistance);
    }
}
