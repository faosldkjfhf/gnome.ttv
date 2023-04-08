using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSense : MonoBehaviour
{
    public Slider sensitivitySlider;
    public float mouseSensitivity = 100;
    public float Sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The lower the value of the slider, the lower the mouse sensitivity in game
        mouseSensitivity = mouseSensitivity * sensitivitySlider.value;
    }
}
