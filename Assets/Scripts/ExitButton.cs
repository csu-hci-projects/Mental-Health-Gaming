using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject exitWindow;

    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            StopDisplay();
        }
    }

    public void DisplayExitWindow()
    {
        Time.timeScale = 0f;
        exitWindow.SetActive(true);
    }

    public void StopDisplay()
    {
        exitWindow.SetActive(false);
        Time.timeScale = 1f;
    }
}
