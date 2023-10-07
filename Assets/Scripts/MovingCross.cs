using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCross : MonoBehaviour
{

    public bool cross = false;

    public int rotationSpeed = 5;

    public Transform up, down, left, right;

    public Vector3 rotationDirection;

    private void Start()
    {

        if (cross)
        {



        }

    }

    void Update()
    {

        if (cross)
        {

            this.gameObject.transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);

        }

        else
        {

            if (this.gameObject.name == "up")
                transform.position = up.position;

            else if (this.gameObject.name == "down")
                transform.position = down.position;

            else if (this.gameObject.name == "right")
                transform.position = right.position;

            else if (this.gameObject.name == "left")
                transform.position = left.position;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !cross)
            collision.transform.SetParent(this.gameObject.transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !cross)
            collision.transform.SetParent(null);

    }

}
