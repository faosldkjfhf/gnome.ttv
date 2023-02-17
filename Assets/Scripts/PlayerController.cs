using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2f;

    CharacterController controller;

    // gets the character controller
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // handles movement 
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 controlInput = playerSpeed *
            (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        controller.Move(controlInput * Time.deltaTime);
        
    }
}
