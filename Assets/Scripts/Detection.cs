using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("GameOver"))
        {
            gameObject.GetComponentInParent<CanelitaIA>().isDetecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("GameOver"))
        {
            gameObject.GetComponentInParent<CanelitaIA>().isDetecting = false;
            gameObject.GetComponentInParent<CanelitaIA>().stoppedDetecting = true;
        }
    }
}
