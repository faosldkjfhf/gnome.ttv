using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject explosion;

    // direct hit on the ground or level
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Solid"))
        {
            // Debug.Log("collided");
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // direct hit on enemy
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
