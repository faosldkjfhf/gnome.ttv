using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLevelNext : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            Debug.Log("going to " + LevelScriptableObject.currentScene);
            SceneManager.LoadScene(3);//LevelScriptableObject.currentScene);
        }
    }
}