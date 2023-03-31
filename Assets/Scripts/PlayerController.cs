using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 2f;
    public float gravity = 9.81f;
    public float airControl = 10f;
    public float jumpHeight = 3.0f;

    public AudioSource walkingSFX;

    Vector3 moveDirection;
    CharacterController controller;
    float finalSpeed;

    void Awake() {
        walkingSFX = GetComponent<AudioSource>();
        walkingSFX.volume = 0.5f;
        controller = GetComponent<CharacterController>();

    }
    // gets the character controller
    void Start()
    {
        finalSpeed = playerSpeed;
         
    }

    // handles movement 
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // if the player is pressing the sprint key (left shift), moves faster
        if (Input.GetKey(KeyCode.LeftShift)) {
            finalSpeed = playerSpeed * 2;
        } 
        else {
            finalSpeed = playerSpeed;
        }

        Vector3 controlInput = finalSpeed *
            (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        if (controller.isGrounded)
        {
            moveDirection = controlInput;
            // if the player is moving, play walkingSFX
            if (!controlInput.Equals(Vector3.zero)) {
                // if the player is running, louder footsteps
                if (finalSpeed == playerSpeed * 2) {
                    walkingSFX.volume = 1f;
                } else {
                    walkingSFX.volume = 0.5f;
                }
                walkingSFX.enabled = true;
            } else {
                walkingSFX.enabled = false;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
        }
        else
        {
            controlInput.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, controlInput, airControl * Time.deltaTime);
        }


        // if (!moveDirection.Equals(Vector3.zero)) {
        //     if (!audioSource.isPlaying) {
        //         Debug.Log("Playing");
        //         audioSource.Play(0);
        //     }
        //     else {
        //         Debug.Log("STOPPING");
        //         audioSource.Stop();
        //     }
        // }
        
        // // plays the walking sound effect if the player is moving 
        // if (m) {
            
        // } else {
        //     AudioSource.PlayClipAtPoint(walkingSFX, Camera.main.transform.position);
        // }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
