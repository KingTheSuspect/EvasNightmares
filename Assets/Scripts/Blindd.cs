using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindd : MonoBehaviour
{
    [SerializeField] private GameObject blindobject;
    private float timer;
    [SerializeField] private float time;
    private bool b;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            b = !b;
            timer = 0;
        }


        blindobject.SetActive(b);
    }
}
