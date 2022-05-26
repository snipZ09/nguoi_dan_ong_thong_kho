using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LevelManager.instance.haveKey)
            {
                UIController.instance.fadeScreen.SetActive(true);
            }
        }
    }
}
