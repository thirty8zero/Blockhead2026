using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public GameObject letter1;
    public GameObject letter2;
    public GameObject letter3;
    public GameObject letter4;
    public GameObject letter5;
    public GameObject letter6;
    public GameObject games;
    public GameObject fadeCanvas;

    // Use this for initialization
    void Start () {

        Invoke("LoadScene", 9f);
        Invoke("LetterOne", 1.5f);
        Invoke("LetterTwo", 2f);
        Invoke("LetterThree", 2.5f);
        Invoke("LetterFour", 3f);
        Invoke("LetterFive", 3.5f);
        Invoke("LetterSix", 4f);
        Invoke("Gamer", 4.5f);
        Invoke("FadeOut", 7f);

    }
	
	// Update is called once per frame
	void LoadScene ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void LetterOne()
    {
        letter1.gameObject.SetActive(true);
    }

    void LetterTwo()
    {
        letter2.gameObject.SetActive(true);
    }

    void LetterThree()
    {
        letter3.gameObject.SetActive(true);
    }

    void LetterFour()
    {
        letter4.gameObject.SetActive(true);
    }

    void LetterFive()
    {
        letter5.gameObject.SetActive(true);
    }

    void LetterSix()
    {
        letter6.gameObject.SetActive(true);
    }

    void Gamer()
    {
        games.gameObject.SetActive(true);
    }

    void FadeOut()
    {
        fadeCanvas.gameObject.SetActive(true);
    }
}
