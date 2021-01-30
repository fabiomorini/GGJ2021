using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchHearth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("GameOver"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().GameOver();
        }
    }
}
