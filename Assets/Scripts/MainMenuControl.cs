using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartGame();
        }
        if(Input.GetButtonDown("Fire3"))
        {
            ExitGame();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
