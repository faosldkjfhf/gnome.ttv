using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public GameObject rake;
    public AudioClip rakeSFX;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    bool canAttack = true;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Melee"))
        {
            if (canAttack)
            {
                RakeAttack();
            }
        }
    }

    public void RakeAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = rake.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());

        AudioSource.PlayClipAtPoint(rakeSFX, Camera.main.transform.position);
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1);
        isAttacking = false;
    }
}
