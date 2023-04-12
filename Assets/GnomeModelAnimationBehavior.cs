using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeModelAnimationBehavior : MonoBehaviour
{
    BasicEnemyBehavior enemyProperties;
    Animator gnomeModelAnimator;
    // Start is called before the first frame update
    void Start()
    {
        enemyProperties = gameObject.transform.parent.GetComponent<BasicEnemyBehavior>();
        gnomeModelAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyProperties.isWalking)
        {
            Debug.Log("walking yeahhh");
            gnomeModelAnimator.SetBool("isWalking", true);
        }
        else 
        {
            gnomeModelAnimator.SetBool("isWalking", false);
        }
    }
}
