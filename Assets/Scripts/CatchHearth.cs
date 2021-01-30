using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchHearth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.gameObject.CompareTag("GameOver"))
        {
            StartCoroutine(Anim());
        }
    }

    private IEnumerator Anim()
    {
        gameObject.GetComponentInParent<CanelitaIA>().justAttacked = true;
        gameObject.GetComponentInParent<CanelitaIA>().isDetecting = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().speed = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().blockSpeed = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().anim.animation.Play(("Hurt_GameOver"), 1);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().blood = GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().blood - 2;
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().blockSpeed = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().speed = 15f;
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().anim.animation.Play(("Idle_Walk"), -1);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponentInParent<CanelitaIA>().justAttacked = false;
    }
}
