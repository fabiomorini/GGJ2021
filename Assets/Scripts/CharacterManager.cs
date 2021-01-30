using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector]public int coins;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
