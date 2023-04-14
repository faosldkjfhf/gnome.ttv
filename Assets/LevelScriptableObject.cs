using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public int currentLevelGoal = LEVEL_INFO.ElementAt(0).Value;


    public void AdvanceLevel() {
        currentLevel += 1;
        currentLevelGoal = LEVEL_INFO.ElementAt(currentLevel).Value;
    }
}






