﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineTrigger : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
