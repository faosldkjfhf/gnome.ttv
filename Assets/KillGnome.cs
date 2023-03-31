using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGnome : MonoBehaviour
{
    public AudioClip gnomeDeadSFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BasicEnemyBehavior enemyProperties = collision.gameObject.GetComponent<BasicEnemyBehavior>();
            if (!enemyProperties.isDead) {
                // Animator gnomeAnimator = collision.gameObject.GetComponent<Animator>();
                // gnomeAnimator.SetTrigger("isDead");
                enemyProperties.isDead = true;
                GameObject.FindObjectOfType<LevelManager>().TrackKill();
                AudioSource.PlayClipAtPoint(gnomeDeadSFX, collision.gameObject.transform.position, 10f);
                Destroy(collision.gameObject, 0.2f);
                Destroy(gameObject);
            }
            
            
        }
    }
}
