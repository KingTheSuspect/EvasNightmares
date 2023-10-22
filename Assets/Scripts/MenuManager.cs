using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private int stageInt;
    [SerializeField] private RectTransform recTransform;
    [SerializeField] private float xOffset , xOffset1, xOffset2, xOffset3;
    [SerializeField] private float speed;



    private Vector3 targetPosition;
   

    private void Update()
    {

        targetPosition = new Vector3(xOffset, recTransform.position.y, recTransform.position.z);
        recTransform.position = Vector3.Lerp(recTransform.position, targetPosition, speed * Time.deltaTime);




        if (stageInt < 1)
        {
            stageInt = 1;
        }

        if (stageInt > 3)
        {
            stageInt = 3;
        }

        if (stageInt == 1)
        {
            xOffset = xOffset1;
        }

        else if (stageInt == 2)
        {
            xOffset = xOffset2;

        }

        else if (stageInt == 3)
        {
            xOffset = xOffset3;

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
   
    }
}
