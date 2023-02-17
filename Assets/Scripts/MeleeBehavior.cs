using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehavior : MonoBehaviour
{
    public float meleeRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pressed the left mouse button
        if (Input.GetMouseButtonDown(1)) {
            InflictMeleeDamage();
        }
    }

    // checks if the player has hit something 
    void InflictMeleeDamage() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, meleeRange)) {
            if(hit.collider.CompareTag("Enemy")) {
                // TODO
                // EnemyHealthScript enemyHealthScript = hit.GetComponent<EnemyHealthScript>();
                // enemyHealthScript.TakeDamage(15f);
            }
        } 
    }

}
