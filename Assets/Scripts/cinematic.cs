using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematic : MonoBehaviour
{
    public GameObject skip;

    private void Start()
    {
        StartCoroutine(Cinematic());
    }

    private IEnumerator Cinematic()
    {
        yield return new WaitForSeconds(3);
        skip.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SoundManager.PlaySound("Click2");
    }
}
