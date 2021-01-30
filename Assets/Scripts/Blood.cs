using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private GameObject Player;
    bool isTouching = false;
    bool alreadyUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (isTouching && !alreadyUsed)
        {
            StartCoroutine(UseBlood());
        }
    }

    private IEnumerator UseBlood()
    {
        alreadyUsed = true;
        yield return new WaitForSeconds(0.01f);
        Player.GetComponent<HearthController>().SetBlood();
        gameObject.SetActive(false); // que cambie el sprite
    }
}
