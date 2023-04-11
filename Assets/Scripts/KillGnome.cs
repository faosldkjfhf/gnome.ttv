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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            BasicEnemyBehavior enemyProperties = other.GetComponent<BasicEnemyBehavior>();
            if (!enemyProperties.isDead) {
                Animator gnomeAnimator = other.GetComponent<Animator>();
                gnomeAnimator.SetTrigger("isDead");
                enemyProperties.isDead = true;
                GameObject.FindObjectOfType<LevelManager>().TrackKill();
                AudioSource.PlayClipAtPoint(gnomeDeadSFX, other.transform.position, 10f);
                Destroy(other, 1f);
                Destroy(gameObject);
            }
        }
    }
}
