using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>().coins += 10;
            SoundManager.PlaySound("CoinSound");
        }
    }
}
