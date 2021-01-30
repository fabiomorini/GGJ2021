using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Anim());
        }
    }

    private IEnumerator Anim()
    {
            GameObject.FindGameObjectWithTag("Player").GetComponent<HearthController>().anim.animation.Play(("Happy_PowerUp_Finish"), 1);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
