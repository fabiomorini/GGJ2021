using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip hoverMenuSound, clickMenuSound, titleSound, 
                            returnSound, playSound, ambientSound, 
                            walkingSound, healingSound, victorySound, lostSound;

    static AudioSource audioSrc;

    public void Start()
    {
        playSound = Resources.Load<AudioClip>("Play");
        titleSound = Resources.Load<AudioClip>("Title");
        returnSound = Resources.Load<AudioClip>("Return");
        hoverMenuSound = Resources.Load<AudioClip>("HoverMenu");
        clickMenuSound = Resources.Load<AudioClip>("ClickMenu");
        ambientSound = Resources.Load<AudioClip>("Ambient");
        walkingSound = Resources.Load<AudioClip>("Walking");
        victorySound = Resources.Load<AudioClip>("Victory");
        lostSound = Resources.Load<AudioClip>("Lost");
        healingSound = Resources.Load<AudioClip>("Healing");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Play":
                audioSrc.PlayOneShot(playSound);
                break;
            case "Return":
                audioSrc.PlayOneShot(returnSound);
                break;
            case "HoverMenu":
                audioSrc.PlayOneShot(hoverMenuSound);
                break;
            case "ClickMenu":
                audioSrc.PlayOneShot(clickMenuSound);
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
            case "Title":
                audioSrc.PlayOneShot(titleSound);
                break;
        }
    }
}
