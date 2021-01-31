using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineTrigger : MonoBehaviour
{
    public GameObject text;
    public GameObject UI;
    private bool inTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
            inTrigger = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            UI.SetActive(true);
            SoundManager.PlaySound("OpenVending");
        }
        else if(!inTrigger)
        {
            UI.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
            text.SetActive(false);
        }
    }
}
