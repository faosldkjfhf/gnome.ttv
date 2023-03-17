using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int damageAmount = 10;
    Animator anim;
    float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Melee"))
        {
            anim = InventoryManager.currentWeaponPrefab.GetComponent<Animator>();
            anim.SetBool("isHitting", true);
            elapsedTime += Time.deltaTime;
        }

        if (anim.GetBool("isHitting")) {
            if (elapsedTime < anim.GetCurrentAnimatorStateInfo(0).length)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0.0f;
                anim.SetBool("isHitting", false);
            }
        }
        Debug.Log(anim.GetBool("isHitting"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (anim.GetBool("isHitting") && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit by melee!");
        }
    }
}
