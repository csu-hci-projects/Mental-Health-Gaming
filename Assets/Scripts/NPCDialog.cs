using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBoxStart;
    public GameObject dialogBoxFinish;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        dialogBoxStart.SetActive(false);
        dialogBoxFinish.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if(timerDisplay < 0)
            {
                dialogBoxStart.SetActive(false);
                dialogBoxFinish.SetActive(false);
            }
        }
    }

    public void DisplayQuestDialog()
    {
        timerDisplay = displayTime;
        dialogBoxStart.SetActive(true);
    }

    public void DisplayFinishDialog()
    {
        timerDisplay = displayTime;
        dialogBoxFinish.SetActive(true);
    }
}
