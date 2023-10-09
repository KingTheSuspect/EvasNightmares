using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public float electricity = 0, electric = 0;
    public bool doit = false, characther = false, crate = false;
    public float timer = 0, speed = 1;
    public Sprite on, off;

    private void Update()
    {

        if (doit && timer >= 0.01f)
        {

            if (electricity == 100)
            {

                electric += speed;

                timer = 0;

            }

            else if (electricity == 0)
            {

                electric -= speed;

                timer = 0;

            }

            if(electric == 100 || electric == 0)
            {

                doit = false;

            }

        }

        timer += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !crate)
        {

            electricity = 100;

            characther = true;

            doit = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = on;

        }

        else if (collision.gameObject.tag == "Ground" && !characther)
        {

            electricity = 100;

            crate = true;

            doit = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = on;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && !crate)
        {

            electricity = 0;

            characther = false;

            doit = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = off;

        }

        else if (collision.gameObject.tag == "Ground" && !characther)
        {

            electricity = 0;

            crate = false;

            doit = true;

            this.gameObject.GetComponent<SpriteRenderer>().sprite = off;

        }

    }

}
