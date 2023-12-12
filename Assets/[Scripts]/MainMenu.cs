using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject HowToPlayUI;

    public AudioClip buttonSound;

    private void Start()
    {
        mainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
    }

    public void HowToPlay()
    {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        mainMenuUI.SetActive(false);
        HowToPlayUI.SetActive(true);
    }

    public void LoadGameplay()
    {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        SceneManager.LoadScene("LevelGameplay");
    }

    public void BackBtn()
    {
        AudioSource.PlayClipAtPoint(buttonSound, transform.position);
        mainMenuUI.SetActive(true);
        HowToPlayUI.SetActive(false);
    }
}
