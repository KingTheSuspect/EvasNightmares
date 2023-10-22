using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int stageInt;
    [SerializeField] private GameObject stage1, stage2, stage3;

    private void Update()
    {
        if (stageInt < 1)
        {
            stageInt = 1;
        }

        if (stageInt > 6)
        {
            stageInt = 6;
        }

        if (stageInt == 1)
        {
            hideAll();
            stage1.SetActive(true);
        }

        else if (stageInt == 2)
        {
            hideAll();
            stage2.SetActive(true);
        }

        else if (stageInt == 3)
        {
            hideAll();
            stage3.SetActive(true);
        }


    }

    public void prevousButton()
    {
        stageInt--;
    }

    public void nextButton()
    {
        stageInt++;

    }

    void hideAll()
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);

    }
}
