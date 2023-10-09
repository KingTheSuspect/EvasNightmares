using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject main;
    public GameObject settings;
    public GameObject credits;
    public LanguageSettings[] ls;
    public bool languageTr, languageEn;
    public void Start()
    {

        hideAll();
        languageEn = true;
        main.SetActive(true);

    }
    public void StartTheGame()
    {

        SceneManager.LoadScene(1);

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

    public void TrLanguage()
    {
        languageTr = true;
        languageEn = false;
    }

    public void EnLanguage()
    {
        languageTr = false;
        languageEn = true;
    }
    void hideAll()
    {

        main.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);

    }

}
