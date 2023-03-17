using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeRotationTest : MonoBehaviour
{

    // the player
    public Transform player;

    // the speed at which the enemy moves
    public float speed = 2f;

    // the max range of the enemy detection
    public float maxDistance = 30f;

    // the min range of enemy detection to prevent weird collisions
    public float minDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(player);
        transform.Rotate(new Vector3(-90, 270, 90));
        var distance = Vector3.Distance(transform.position, player.position);
        var step = speed * Time.deltaTime;
        if (distance <= maxDistance && distance >= minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }
}
