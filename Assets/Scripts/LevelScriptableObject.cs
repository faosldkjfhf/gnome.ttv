using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "gnome.ttv/LevelScriptableObject", order = 0)]
public class LevelScriptableObject : ScriptableObject {
    // a mapping of the information in each level's LevelManager
    public static Dictionary<string, int> LEVEL_INFO = new Dictionary<string, int>() {
        {"main-house", 10}, 
        {"neighbor-house", 50}, 
        {"garden", 150}, 
    };

    public int currentLevel = 0;

    //public int currentLevelGoal = LEVEL_INFO.ElementAt(0).Value;

    public static string currentScene = "main-house";
    public int currentLevelGoal = LEVEL_INFO[currentScene];

    private void OnEnable()
    {
        currentScene = SceneManager.GetActiveScene().name;
        currentLevelGoal = LEVEL_INFO[currentScene];
    }

    // saves the level information
    public void SaveLevelInformation() {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.SetString("currentScene", currentScene);
        PlayerPrefs.SetInt("currentLevelGoal", currentLevelGoal);
    }

    // loads the saved level information 
    public void LoadLevelInformation() {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        currentScene = PlayerPrefs.GetString("currentScene");
        currentLevelGoal = PlayerPrefs.GetInt("currentLevelGoal");
    }

    // increases level index by one and updates all level info values
    public void AdvanceLevel() {
        currentLevel += 1;
        currentScene = LEVEL_INFO.ElementAt(currentLevel).Key;
        currentLevelGoal = LEVEL_INFO.ElementAt(currentLevel).Value;
        SaveLevelInformation();
    }

    // when a level is loaded, updates all level info values
    public void UpdateProperties()
    {  
        currentScene = SceneManager.GetActiveScene().name;
        currentLevel = LEVEL_INFO.Keys.ToList().IndexOf(currentScene);
        currentLevelGoal = LEVEL_INFO[currentScene];
        SaveLevelInformation();
    }

    // prints level info values 
    public void PrintLevelInfo() {
        Debug.Log("level index: " + currentLevel.ToString());
        Debug.Log("current scene: "  + currentScene);
        Debug.Log("current level goal: "  + currentLevelGoal.ToString());
    }
}






