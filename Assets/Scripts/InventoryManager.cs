using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// this inventory system currently supports equipping two weapons 
public class InventoryManager : MonoBehaviour
{
    public int selectedSlot = 0;

    public GameObject[] weapons;

    public static GameObject currentWeaponPrefab; 

    // tracks keycodes for indexing 
    private KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponPrefab = weapons[0];
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedSlot = selectedSlot;

        // checks if the scroll wheel is used to swap weapon slots 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if (selectedSlot >= weapons.Length - 1) {
                selectedSlot = 0;
            } 
            else {
                selectedSlot++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (selectedSlot <= 0) {
                selectedSlot = weapons.Length - 1;
            }
            else {
                selectedSlot--;
            }
        }

        
        // check if number keys are used to swap weapon slots 
        for (int i = 0; i < keyCodes.Length; i++) {
            if (Input.GetKey(keyCodes[i])) {
                // Debug.Log("HI");
                selectedSlot = i;
            }
        }

        if (previousSelectedSlot != selectedSlot) {
            SelectWeapon();
        }
    }

    void SelectWeapon() {
        int i = 0;
        /*foreach (Transform weapon in transform) {
            if (i == selectedSlot) {
                weapon.gameObject.SetActive(true);
                currentWeaponPrefab = weapon.gameObject;
                // Debug.Log(currentWeaponPrefab.tag);
            }
            else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }*/
        foreach(GameObject weapon in weapons)
        {
            if (i == selectedSlot)
            {
                currentWeaponPrefab = weapon;
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
            i++;
        }
    }
}
