using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCross : MonoBehaviour
{

    [SerializeField] private bool cross = false;

    [SerializeField] private int rotationSpeed = 5;

    [SerializeField] private Transform up, down, left, right;

    [SerializeField] private Vector3 rotationDirection;

    [SerializeField] private float maxRotation;

    void Update()
    {

        if (cross)
        {

            this.gameObject.transform.Rotate(rotationSpeed * rotationDirection);

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

        if (collision.gameObject.CompareTag("Player") && !cross)
            collision.transform.SetParent(this.gameObject.transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !cross)
            collision.transform.SetParent(null);

    }

}
