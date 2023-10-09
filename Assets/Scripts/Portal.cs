using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    [SerializeField] public bool useNumber = false;
    [SerializeField] public int number;

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
