using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSense : MonoBehaviour
{
    public Slider sensitivitySlider;


    // Start is called before the first frame update
    void Start()
    { 
        sensitivitySlider.value = MouseLook.mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        //The lower the value of the slider, the lower the mouse sensitivity in game
        MouseLook.mouseSensitivity = sensitivitySlider.value;
        Debug.Log("Mouse Sense" + MouseLook.mouseSensitivity);
    }
}
