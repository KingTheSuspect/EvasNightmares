using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform point1, point2;
    public float speed = 3;
    [SerializeField] private bool vertical;
    public Vector3 targetPos;

    private void Start()
    {

        targetPos = point2.position;

    }

    void Update()
    {

        if (!vertical) { 

            if (this.transform.position.x <= point1.position.x)
                targetPos = point2.position;

            else if (this.transform.position.x >= point2.position.x)
                targetPos = point1.position;

        }

        else if (vertical)
        {

            if (this.transform.position.y <= point2.position.y)
                targetPos = point1.position;

            else if (this.transform.position.y >= point1.position.y)
                targetPos = point2.position;

        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
            collision.transform.SetParent(this.gameObject.transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
            collision.transform.SetParent(null);

    }

}
