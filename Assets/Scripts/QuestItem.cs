using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        TravelerController controller = other.GetComponent<TravelerController>();

        if(controller  != null)
        {
            controller.UpdateInventory(gameObject, 1);
            Destory(gameObject);
        }
    }
}
