using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackRate = 2f;
    public AudioClip swingSFX;

    Animator anim;
    float elapsedTime = 0f;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Melee"))
        {

            anim = InventoryManager.currentWeaponPrefab.GetComponent<Animator>();
            if (elapsedTime >= attackRate)
            {
                AudioSource.PlayClipAtPoint(swingSFX, Camera.main.transform.position);
                anim.SetBool("isHitting", true);
                elapsedTime = 0.0f;
            }
        }


        if (anim != null && anim.GetBool("isHitting"))
        {
            if (elapsedTime >= anim.GetCurrentAnimatorStateInfo(0).length)
            {
                anim.SetBool("isHitting", false);
            }
        }
        
        elapsedTime += Time.deltaTime;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (anim.GetBool("isHitting") && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by melee!");
        }
    }
}
