using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool paused = false;
    public GameObject pauseMenu;

    void Start()
    {

        pauseMenu = GameObject.Find("PauseMenu");

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) paused = !paused;

        if (paused) { Time.timeScale = 0; pauseMenu.SetActive(true); }
        else { Time.timeScale = 1; pauseMenu.SetActive(false); }

    }

}
