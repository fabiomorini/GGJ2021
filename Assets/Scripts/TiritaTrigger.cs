using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiritaTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>().tirita = true;
            SoundManager.PlaySound("Blood");
            Destroy(gameObject);
        }
    }
}
