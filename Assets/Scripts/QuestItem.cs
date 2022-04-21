using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public float displayTime = 1.0f;
    public GameObject itemAlert;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        itemAlert.SetActive(false);
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
                itemAlert.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    public void QuestItemAlert()
    {
        timerDisplay = displayTime;
        itemAlert.SetActive(true); 
    }
}
