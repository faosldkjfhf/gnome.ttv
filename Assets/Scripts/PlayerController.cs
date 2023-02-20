using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float gravity = 9.81f;
    public float airControl = 10f;
    Vector3 moveDirection;
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

        if (controller.isGrounded)
        {
            moveDirection = controlInput;
        }
        else
        {
            controlInput.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, controlInput, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
