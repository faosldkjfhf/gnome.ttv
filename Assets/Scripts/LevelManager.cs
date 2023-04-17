using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text gameText;
    public Text scoreText;
    public GameObject uiPanel;
    public LevelScriptableObject levelProperties;

    [Tooltip("How many enemies to kill to pass level")]
    public int enemiesToSpawn = 10;

    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;

    public static float score;

    public static bool isGameOver = false;

    public string nextLevel;

    // how many enemies have spawned by the spawners 
    int enemyHasSpawned = 0; 

    int enemiesKilled = 0;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        levelProperties.UpdateProperties();
        enemiesToSpawn = levelProperties.currentLevelGoal;
        score = 0;

        SetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("enemies to beat: " + enemiesToSpawn);
        if (!isGameOver) {
            SetScoreText();
           if (enemiesKilled >= enemiesToSpawn) {
                isGameOver = true;
           }
        }
        
    }

    // tracks how many enemies have spawned 
    public void TrackSpawn() {
        enemyHasSpawned += 1;
    }

    // tracks how many enemies have been killed 
    public void TrackKill() {
        enemiesKilled += 1;
        score = enemiesKilled;
    }

    // spawns enemies if more should be spawned 
    public bool ShouldSpawnMore() {
        return enemyHasSpawned < enemiesToSpawn;
    }

    void SetScoreText() {
        scoreText.text = "Score: " + score.ToString();
    }

    public void LevelLost()
    {
        isGameOver = true;
        gameText.text = "GAME OVER!";
        uiPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        uiPanel.gameObject.SetActive(true);
        gameText.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);

        Invoke("LoadCurrentLevel", 2);
    }

    public void LevelBeat() {
        isGameOver = true;
        gameText.text = "YOU WIN!";
        uiPanel.GetComponent<Image>().color =  new Color(1, 1, 1, 0.5f);
        uiPanel.gameObject.SetActive(true);
        gameText.gameObject.SetActive(true);
        

        AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

        if (!string.IsNullOrEmpty(nextLevel)) {
            Invoke("LoadNextLevel", 2);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
