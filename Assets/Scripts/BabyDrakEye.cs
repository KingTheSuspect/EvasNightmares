using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDrakEye : MonoBehaviour
{

    public BabyDrake bd;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            bd.isSeeing = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            bd.isSeeing = false;

        }

    }

}
