using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    [Range(1,3)]
    [SerializeField] private int stageInt;
    [SerializeField] private RectTransform recTransform;
    [SerializeField] private float xOffset , xOffset1, xOffset2, xOffset3;
    [SerializeField] private float speed;
    [SerializeField] private float cooldown, timer;



    private Vector3 targetPosition;
   

    private void Update()
    {
        timer += Time.deltaTime;
        targetPosition = new Vector3(xOffset, recTransform.position.y, recTransform.position.z);
        recTransform.position = Vector3.Lerp(recTransform.position, targetPosition, speed * Time.deltaTime);




     

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
        if (timer >= cooldown)
        {
            stageInt--;
            timer = 0;
        }
    }

    public void nextButton()
    {
        if (timer >= cooldown)
        {
            stageInt++;
            timer = 0;

        }


    }

    void hideAll()
    {
   
    }
}
