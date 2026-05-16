using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallDestroyPlayer : MonoBehaviour
{

    public GameObject player;
    public GameObject explosion;
    public GameObject cameraToAccess;

    string currentScene;

    private LevelTimer levelTimer;
    //private TimerManager timerManager;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        levelTimer = Object.FindFirstObjectByType<LevelTimer>();
        //timerManager = FindObjectOfType<TimerManager>();
    }

    void OnCollisionStay(Collision collider)

    {
        if (GameObject.FindWithTag("Player"))

        {
            cameraToAccess.GetComponent<CameraController>().enabled = false;
            Instantiate(explosion, player.transform.position, player.transform.rotation);
            //DestroyObject(player);
            Object.Destroy(player);
            Invoke("SlowTime", 0.08f);
            Invoke("SpeedTime", 0.14f);
            Invoke("LoadLevel", 3f);

            if (levelTimer != null)
            {
                // Player destroyed = stop timer, but don’t save
                levelTimer.StopTimer(false);
            }
        }

    }

    void SlowTime()
    {
        Time.timeScale = 0.03f;
    }

    void SpeedTime()
    {
        Time.timeScale = 1f;
    }

    void LoadLevel()

    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // if (currentScene == "LevelTemplate")

        // {
        //     SceneManager.LoadScene("LevelTemplate");
        // }

        // if (currentScene == "LevelTutorial")

        // {
        //     SceneManager.LoadScene("LevelTutorial");
        // }

        // if (currentScene == "NewTemplate")

        // {
        //     SceneManager.LoadScene("NewTemplate");
        // }

        // if (currentScene == "LevelOne")

        // {
        //     SceneManager.LoadScene("LevelOne");
        // }

        // if (currentScene == "LevelTwo")

        // {
        //     SceneManager.LoadScene("LevelTwo");
        // }

        // if (currentScene == "Level_4A")

        // {
        //     SceneManager.LoadScene("Level_4A");
        // }
    }
}


