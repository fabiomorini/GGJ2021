using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector]public int coins;
    [HideInInspector] public bool tirita, cafe, desfibrilador;

    private void Start()
    {
        coins = 0;

        DontDestroyOnLoad(gameObject);
    }
}
