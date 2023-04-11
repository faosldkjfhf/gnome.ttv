using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Transform playerBody;
    public static float mouseSensitivity = 100;
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent.transform;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        print("mouseSense" + mouseSensitivity);
    
        // yaw
        playerBody.Rotate(Vector3.up * moveX);

        // pitch 
        pitch -= moveY;

        pitch = Mathf.Clamp(pitch, -90f, 90);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    public void AdjustSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 10;
    }
}