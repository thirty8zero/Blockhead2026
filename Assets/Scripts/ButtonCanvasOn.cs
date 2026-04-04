using UnityEngine;

public class ButtonCanvasOn : MonoBehaviour
{

    public GameObject canvas;
    public bool onOff = true;
    void Start()
    {
        //canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Toggle"))

        {
            onOff = !onOff;
        }

        if (onOff == true)
        {
            canvas.SetActive(true);
        }

        if (onOff == false)
        {
            canvas.SetActive(false);
        }

    }
}

