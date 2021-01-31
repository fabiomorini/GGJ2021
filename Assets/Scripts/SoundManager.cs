using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip hoverMenuSound, clickMenuSound, titleSound1, titleSound2, levelendSound, bloodSound, 
                            returnSound, playSound, ambientSound, detectionSound, insertCoin, 
                            walkingSound, healingSound, victorySound, lostSound, openVSound, closeVSound;

    static AudioSource audioSrc;

    public void Start()
    {
        playSound = Resources.Load<AudioClip>("Click");
        titleSound1 = Resources.Load<AudioClip>("Title1");
        titleSound2 = Resources.Load<AudioClip>("Title2");
        returnSound = Resources.Load<AudioClip>("Return");
        hoverMenuSound = Resources.Load<AudioClip>("Hover");
        ambientSound = Resources.Load<AudioClip>("Ambient");
        levelendSound = Resources.Load<AudioClip>("LevelEnd");
        walkingSound = Resources.Load<AudioClip>("Walking");
        victorySound = Resources.Load<AudioClip>("Victory");
        lostSound = Resources.Load<AudioClip>("Lost");
        healingSound = Resources.Load<AudioClip>("Healing");
        bloodSound = Resources.Load<AudioClip>("Blood");
        detectionSound = Resources.Load<AudioClip>("Detection");
        openVSound = Resources.Load<AudioClip>("OpenVending");
        closeVSound = Resources.Load<AudioClip>("ClosingVending");
        insertCoin = Resources.Load<AudioClip>("InsertCoin");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Click":
                audioSrc.PlayOneShot(playSound);
                break;
            case "Return":
                audioSrc.PlayOneShot(returnSound);
                break;
            case "HoverMenu":
                audioSrc.PlayOneShot(hoverMenuSound);
                break;
            case "ambient":
                audioSrc.PlayOneShot(ambientSound);
                break;
            case "walking":
                audioSrc.PlayOneShot(walkingSound);
                break;
            case "victory":
                audioSrc.PlayOneShot(victorySound);
                break;
            case "lost":
                audioSrc.PlayOneShot(lostSound);
                break;
            case "Healing":
                audioSrc.PlayOneShot(healingSound);
                break;
            case "Title1":
                audioSrc.PlayOneShot(titleSound1);
                break;
            case "Title2":
                audioSrc.PlayOneShot(titleSound2);
                break;            
            case "LevelEnd":
                audioSrc.PlayOneShot(levelendSound);
                break;            
            case "Blood":
                audioSrc.PlayOneShot(bloodSound);
                break;            
            case "Detection":
                audioSrc.PlayOneShot(detectionSound);
                break;           
            case "OpenVending":
                audioSrc.PlayOneShot(openVSound);
                break;            
            case "ClosingVending":
                audioSrc.PlayOneShot(closeVSound);
                break;
            case "InsertCoin":
                audioSrc.PlayOneShot(insertCoin);
                break;
        }
    }
}
