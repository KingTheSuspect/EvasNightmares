using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCross : MonoBehaviour
{

    public bool cross = false;

    public int rotationSpeed = 5;

    [SerializeField] private Transform up, down, left, right;

    public int rotationDirection;

    [SerializeField] private float maxRotation;

    private float multiplier = 0, zDir;

    void Update()
    {

        multiplier = this.gameObject.transform.localRotation.eulerAngles.z + (rotationDirection * rotationSpeed * Time.deltaTime);

        if (cross)
        {

            //this.gameObject.transform.Rotate(rotationSpeed * rotationDirection * Time.deltaTime);

            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, multiplier);

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
