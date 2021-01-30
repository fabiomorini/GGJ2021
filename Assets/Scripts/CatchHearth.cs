using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchHearth : MonoBehaviour
{
    private void CatchPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().GameOver();
    }

    private void Update()
    {
        Debug.Log(gameObject.GetComponent<CanelitaIA>().detectionCounter);
        if(gameObject.GetComponent<CanelitaIA>().detectionCounter == 2)
        {
            CatchPlayer();
        }
    }
}
