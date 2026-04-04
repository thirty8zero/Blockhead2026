using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;   // Assign your PauseMenu Canvas here
    private bool isPaused = false;
    private LevelTimer levelTimer;

    void Start()
    {
        levelTimer = Object.FindFirstObjectByType<LevelTimer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // stop game time
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // resume game time
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void ResetBestTime()
    {
        string levelKey = "BestTime_" + SceneManager.GetActiveScene().name;
        PlayerPrefs.SetFloat(levelKey, 0f);
        PlayerPrefs.Save();
        levelTimer.UpdateBestTimeUI();
    }
}
