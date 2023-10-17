using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private GameObject settings;
    public void Start()
    {

        hideAll();

    }
    public void StartTheGame()
    {

        SceneManager.LoadScene(1);

    }

    public void MainMenu()
    {

        hideAll();


    }
    public void SettingsMenu()
    {

        hideAll();

        settings.SetActive(true);

    }
   
    public void Quit()
    {

        Application.Quit();

    }

   
    void hideAll()
    {

        settings.SetActive(false);

    }

}
