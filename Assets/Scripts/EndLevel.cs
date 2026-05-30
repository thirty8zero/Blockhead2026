//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    public bool hasKey;
    public GameObject fadeScreen;
    public GameObject levelText;
    public GameObject player;
    public GameObject bgMusic;
    public GameObject colliderBlock;
    //public GameObject endModel;

    [SerializeField] private BoxCollider playerBoxCollider;

    string currentScene;
    private LevelTimer levelTimer;

    void Start()

    {
        hasKey = false;
        currentScene = SceneManager.GetActiveScene().name;
        levelTimer = Object.FindFirstObjectByType<LevelTimer>();
    }


    void Update()

    {

    }

    private void OnTriggerEnter(Collider other)

    {

        if (other != playerBoxCollider)
            return;

        if (!hasKey)
            return;
        //if (GameObject.FindWithTag("Player") && hasKey == true)

        {
            if (levelTimer != null)
            {
                // Player destroyed = stop timer, but don’t save
                levelTimer.StopTimer(true);
                Debug.Log("Stop Timer true");
            }
            //Invoke("ScreenFade", 0f);
            //Invoke("MusicOff", 0f);
            Invoke("TurnOffPlayer", 0f);
            //Invoke("ShowText", 1.5f);
            Invoke("LoadLevel", 5f);
        }

    }

    void LoadLevel()
    {

        if (currentScene == "LevelTutorial")

        {
            SceneManager.LoadScene("LevelOne");
        }

        if (currentScene == "LevelOne")

        {
            SceneManager.LoadScene("LevelTwo");
        }

        if (currentScene == "LevelTwo")

        {
            SceneManager.LoadScene("LevelTwo");
        }

        if (currentScene == "Level_4A")

        {
            SceneManager.LoadScene("Level_4A");
        }
    }

    void ScreenFade()

    {
        fadeScreen.gameObject.SetActive(true);
        colliderBlock.gameObject.SetActive(true);
    }

    void ShowText()

    {
        levelText.gameObject.SetActive(true);
    }

    void TurnOffPlayer()

    {
        player.GetComponent<PlayerController>().enabled = false;
    }

    void MusicOff()

    {
        bgMusic.GetComponent<Animator>().enabled = true;
    }

    // void EndModel()

    // {
    //     endModel.gameObject.SetActive(true);
    // }
}
