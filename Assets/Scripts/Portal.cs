using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    [SerializeField] private bool useNumber = false;
    [SerializeField] private int number;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            if (useNumber)
            {

                SceneManager.LoadScene(number);

            }

            else
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

        }

    }

}
