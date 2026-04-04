using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIntro : MonoBehaviour
{

    public GameObject title;
    public GameObject fallingBlocks;
    public GameObject buttonCanvas;
    public GameObject fadeInCanvas;
    //public GameObject fadeIn;


    void Start()

    {
        //Invoke("FadeIn", 1f);
        Invoke("FB", 3f);
        Invoke("TitleUp", 4.1f);
        Invoke("Button", 4f);
        Invoke("FadeInOff", 4f);
    }

    void TitleUp()

    {
        title.gameObject.SetActive(true);
    }

    void FB()
    {
        fallingBlocks.gameObject.SetActive(true);
    }

    void Button()
    {
        buttonCanvas.gameObject.SetActive(true);
    }

    void FadeInOff()
    {
        fadeInCanvas.gameObject.SetActive(false);
    }
    //void FadeIn()

    //{
    //    fadeIn.GetComponent<Animator>().enabled = true;
    //}
}
