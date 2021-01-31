﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("CharacterManager").GetComponent<CharacterManager>().desfibrilador = true;
            SoundManager.PlaySound("Blood");
            Destroy(gameObject);
        }
    }
}
