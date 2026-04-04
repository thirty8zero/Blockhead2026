using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TESTMMLOAD : MonoBehaviour
{

    public float loadTime = 5f;

    void Start()
    {

        Invoke("LoadScene", loadTime);

    }

    // Update is called once per frame
    void LoadScene()
    {
        //SceneManager.LoadScene("LevelTutorial");
        SceneManager.LoadScene("Level_4A");
        SceneManager.LoadScene("Loader");
    }

}
