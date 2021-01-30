using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private bool alreadyDone = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("detection"))
        {
            gameObject.GetComponentInParent<CanelitaIA>().isDetecting = true;
            StartCoroutine(Anim());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("detection"))
        {
            gameObject.GetComponentInParent<CanelitaIA>().isDetecting = false;
            gameObject.GetComponentInParent<CanelitaIA>().stoppedDetecting = true;
            gameObject.GetComponentInParent<CanelitaIA>().anim.animation.Play(("Walk_Loop"), -1);
        }
    }

    private IEnumerator Anim()
    {
        if (!alreadyDone)
        {
            gameObject.GetComponentInParent<CanelitaIA>().anim.animation.Play(("Surprise"), 1);
            yield return new WaitForSeconds(1f);
            gameObject.GetComponentInParent<CanelitaIA>().anim.animation.Play(("Run_Loop"), -1);
            alreadyDone = true;
        }
    }
}
