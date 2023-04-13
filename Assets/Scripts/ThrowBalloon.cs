using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBalloon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 30f;
    public float attackSpeed = 1f;
    private bool isAttacking = false;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Throwable"))
        {
            if (canAttack)
            {
                isAttacking = true;
                canAttack = false;
                GameObject projectile =
                    Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;

                Rigidbody rb = projectile.GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

                projectile.transform.SetParent(
                    GameObject.FindGameObjectWithTag("ProjectileParent").transform
                );

                StartCoroutine(AttackCooldown());
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackSpeed);
        isAttacking = false;
        canAttack = true;
    }
}
