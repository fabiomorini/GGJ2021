using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject Player;
    bool isTouching = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = true;
        }
    }

    private void Update()
    {
        if (isTouching)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<HearthController>().SetBlood();
            }
        }
    }
}
