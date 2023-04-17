using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isGamePaused = false;
    public LevelScriptableObject levelProperties;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSavedLevel() {
        levelProperties.LoadLevelInformation();
        if (LevelScriptableObject.currentScene.CompareTo("") == 0)
        {
            return;
        }
        SceneManager.LoadScene(LevelScriptableObject.currentScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f; //stop time
        pauseMenu.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f; //stop time
        pauseMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
