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
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().anim.animation.Play(("Hurt_GameOver"), 1);
        yield return new WaitForSeconds(1f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().anim.animation.Play(("Idle_Walk"), -1);
    }
}
