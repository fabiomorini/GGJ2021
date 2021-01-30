using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject Title1;
    public GameObject Title2;
    public GameObject Title3;
    public GameObject Title4;
    public GameObject Buttons;



    private void Start()
    {
        StartCoroutine(MenuAnim());
    }

    public void Exit()
    {
        StartCoroutine(QuitGame());
    }
    public IEnumerator QuitGame()
    {
        //SoundManager.PlaySound("Return");
        yield return new WaitForSeconds(1.0f);
        Application.Quit();
    }

    public void PlayLevel()
    {
        StartCoroutine(PlayGame());
    }

    public IEnumerator PlayGame()
    {
        //SoundManager.PlaySound("Play");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator MenuAnim()
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title");
        Title1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title");
        Title2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title");
        Title3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title");
        Title4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Buttons.SetActive(true);

    }
}
