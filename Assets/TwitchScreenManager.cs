using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwitchScreenManager : MonoBehaviour
{
    public LevelScriptableObject levelProperties;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
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
        
    }

    void UpdateScoreText() {
        scoreText.text = levelProperties.currentLevelGoal.ToString();
    }
}
