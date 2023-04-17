using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwitchScreenManager : MonoBehaviour
{
    public LevelScriptableObject levelProperties;
    public Text scoreText;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("current level : " + LevelScriptableObject.currentScene);
        if (levelProperties == null) {
            Debug.Log("Scriptable Object not placed into inspector");
        }
        else {
            UpdateScoreText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) {
            Debug.Log("going to " + LevelScriptableObject.currentScene);
            SceneManager.LoadScene(2);//LevelScriptableObject.currentScene);
        }
    }

    void UpdateScoreText() {
        scoreText.text = levelProperties.currentLevelGoal.ToString();
    }
}
