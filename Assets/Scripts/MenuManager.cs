using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int stageInt;
    [SerializeField] private GameObject stage1 , stage2 , stage3, stage4, stage5, stage6;

    private void Update()
    {
        if(stageInt < 1)
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

        else if (stageInt == 4)
        {
            hideAll();
            stage4.SetActive(true);
        }

        else if (stageInt == 5)
        {
            hideAll();
            stage5.SetActive(true);
        }

        else if (stageInt == 6)
        {
            hideAll();
            stage6.SetActive(true);
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
        stage4.SetActive(false);
        stage5.SetActive(false);
        stage6.SetActive(false);
    }

}
