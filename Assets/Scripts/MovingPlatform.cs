using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform point1, point2;
    public float speed = 3;
    public Vector3 targetPos;

    private void Start()
    {

        targetPos = point2.position;

    }

    void Update()
    {

        if (this.transform.position.x <= point1.position.x)
            targetPos = point2.position;

        else if (this.transform.position.x >= point2.position.x)
            targetPos = point1.position;

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
