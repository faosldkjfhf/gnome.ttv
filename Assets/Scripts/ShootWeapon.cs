using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 100;
    public AudioClip shootSFX;

    public Image CrosshairImage;

    Color originalReticleColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Shootable"))
        {
            GameObject projectile =
                Instantiate(
                    projectilePrefab,
                    transform.position + transform.forward,
                    transform.rotation
                ) as GameObject;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);


            rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);

            projectile.transform.SetParent(
                GameObject.FindGameObjectWithTag("ProjectileParent").transform
            );

            //AudioSource.PlayClipAtPoint(shootSFX, transform.position);
        }
    }
}
