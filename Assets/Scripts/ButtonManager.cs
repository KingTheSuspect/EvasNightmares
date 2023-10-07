using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject main;
    public GameObject settings;
    public GameObject credits;

    public void Start()
    {

        hideAll();

        main.SetActive(true);

    }
    public void StartTheGame()
    {

        SceneManager.LoadScene(2);

    }

    public void MainMenu()
    {

        hideAll();

        main.SetActive(true);

    }
    public void SettingsMenu()
    {

        hideAll();

        settings.SetActive(true);

    }
    public void CreditsMenu()
    {

        hideAll();

        credits.SetActive(true);

    }
    public void Quit()
    {

        Application.Quit();

    }
    void hideAll()
    {

        main.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);

    }

}
