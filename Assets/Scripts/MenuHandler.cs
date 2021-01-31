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

    public GameObject ButtonPlay;
    public GameObject ButtonExit;
    public GameObject ButtonCredits;
    public GameObject ButtonReturn;
    public GameObject credits;


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

    public void Credits()
    {
        ButtonPlay.SetActive(false);
        ButtonExit.SetActive(false);
        ButtonCredits.SetActive(false);
        ButtonReturn.SetActive(true);
        credits.SetActive(true);
    }
    public void ReturnCredits()
    {
        ButtonPlay.SetActive(true);
        ButtonExit.SetActive(true);
        ButtonCredits.SetActive(true);
        ButtonReturn.SetActive(false);
        credits.SetActive(false);
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
        SoundManager.PlaySound("Title1");
        Title1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title1");
        Title2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title1");
        Title3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SoundManager.PlaySound("Title2");
        Title4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        ButtonPlay.SetActive(true);
        ButtonExit.SetActive(true);
        ButtonCredits.SetActive(true);

    }
}
