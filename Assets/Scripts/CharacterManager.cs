using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector]public int coins;
    public TMP_Text coinsText;
    public GameObject cafeObj;
    public GameObject tiritaObj;
    public GameObject desfiObj;
    public GameObject coinsImage;
    [HideInInspector] public bool tirita, cafe, desfibrilador;

    private void Start()
    {
        coins = 0;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (tirita)
        {
            tiritaObj.SetActive(true);
        }
        if (cafe)
        {
            cafeObj.SetActive(true);
        }
        if (desfibrilador)
        {
            desfiObj.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            coinsText.SetText("" + coins);
            coinsImage.SetActive(true);
        }

    }
}
