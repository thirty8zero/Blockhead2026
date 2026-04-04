using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{

    private Material mat;
    public int matNumber;
    public Material blueMat;
    public Material greenMat;
    public Material yellowMat;
    public Material redMat;

    public GameObject player;
    public GameObject explosion;
    public GameObject cameraToAccess;

    string currentScene;
    private LevelTimer levelTimer;

    void Start()
    {

        currentScene = SceneManager.GetActiveScene().name;

        mat = gameObject.GetComponent<Renderer>().sharedMaterial;
        if (mat == blueMat)
        {
            matNumber = 1;
        }
        if (mat == greenMat)
        {
            matNumber = 2;
        }
        if (mat == yellowMat)
        {
            matNumber = 3;
        }
        if (mat == redMat)
        {
            matNumber = 4;
        }

        levelTimer = Object.FindFirstObjectByType<LevelTimer>();

    }

    void Update()
    {

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == ("Player"))

        {
            if (other.gameObject.GetComponent<ColourChanger>().playMatNumber != matNumber)

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

        if (currentScene == "TheTester")

        {
            SceneManager.LoadScene("TheTester");
        }

        if (currentScene == "LevelTemplate")

        {
            SceneManager.LoadScene("LevelTemplate");
        }

        if (currentScene == "LevelTutorial")

        {
            SceneManager.LoadScene("LevelTutorial");
        }

        if (currentScene == "LevelOne")

        {
            SceneManager.LoadScene("LevelOne");
        }

        if (currentScene == "NewTemplate")

        {
            SceneManager.LoadScene("NewTemplate");
        }

        if (currentScene == "LevelTwo")

        {
            SceneManager.LoadScene("LevelTwo");
        }

        if (currentScene == "Level_4A")

        {
            SceneManager.LoadScene("Level_4A");
        }

        //if (currentScene == "LevelOneReload")

        //{
        //    SceneManager.LoadScene("LevelOneReload");
        //}
    }
}


