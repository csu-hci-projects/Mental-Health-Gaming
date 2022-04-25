using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitControl : MonoBehaviour
{

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
