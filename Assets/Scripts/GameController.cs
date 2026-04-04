using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour

{

    public bool testingLevel;
    public GameObject loadCamera;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()

    {
        if (!testingLevel)
        {
            //SceneManager.LoadSceneAsync("LevelTutorial");
            SceneManager.LoadSceneAsync("Level_4A");
        }
        Destroy(loadCamera);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
