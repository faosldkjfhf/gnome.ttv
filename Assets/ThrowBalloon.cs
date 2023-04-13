using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBalloon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && InventoryManager.currentWeaponPrefab.CompareTag("Throwable"))
        {

        }
    }
}
