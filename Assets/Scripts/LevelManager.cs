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

    GameObject[] portals;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        levelProperties.UpdateProperties();
        levelProperties.PrintLevelInfo();
        enemiesToSpawn = levelProperties.currentLevelGoal;
        score = 0;

        SetScoreText();

        portals = GameObject.FindGameObjectsWithTag("portal");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("enemies to beat: " + enemiesToSpawn);
        if (!isGameOver)
        {
            SetScoreText();
            if (enemiesKilled >= enemiesToSpawn)
            {
                // deactivate portals
                for (int i = 0; i < portals.Length; i++)
                {
                    portals[i].SetActive(false);
                }
                // game win condition met
                isGameOver = true;

                // tell player to talk to granny to move on
                gameText.text = "All Gnomes Eliminated! \nGo talk to Granny";
                uiPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
                uiPanel.gameObject.SetActive(true);
                gameText.gameObject.SetActive(true);
            }
        }
    }

    // tracks how many enemies have spawned
    public void TrackSpawn()
    {
        enemyHasSpawned += 1;
    }

    // tracks how many enemies have been killed
    public void TrackKill()
    {
        enemiesKilled += 1;
        score = enemiesKilled;
    }

    // spawns enemies if more should be spawned
    public bool ShouldSpawnMore()
    {
        return enemyHasSpawned < enemiesToSpawn;
    }

    void SetScoreText()
    {
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

    public void LevelBeat()
    {
        isGameOver = true;
        gameText.text = "LEVEL CLEARED!";
        levelProperties.AdvanceLevel();
        uiPanel.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        uiPanel.gameObject.SetActive(true);
        gameText.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);

        if (!string.IsNullOrEmpty(nextLevel))
        {
            Invoke("LoadNextLevel", 2.5f);
        }
    }

    // load the gnome.ttv scene
    private void LoadGnomeTTVScene()
    {
        SceneManager.LoadScene("twitch-scene");
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
