using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDrake : MonoBehaviour
{

    public bool isSeeing = false;
    public float firecd = 2f;
    public float speed = 3f;
    public bool right = true;
    public float bulletSpeed = 2f;
    public float timer;
    public Vector2 Scale;

    public Transform point1, point2, spawner;
    public GameObject fireBall;
    public Vector3 spawnerPoints;

    private void Start()
    {

        Scale = this.gameObject.transform.localScale;

    }

    private void Update()
    {

        if (isSeeing)
        {

            Fire();

        }
            
    }

    public void FixedUpdate()
    {

        if (transform.position.x <= point1.position.x)
        {

            right = true;

        }

        else if (transform.position.x >= point2.position.x)
        {

            right = false;

        }

        if (right && !isSeeing)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            this.gameObject.transform.localScale = Scale;

        }

        else if (!right && !isSeeing)
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            this.gameObject.transform.localScale = new Vector2(-Scale.x, Scale.y);

        }

        else
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }

        timer += Time.deltaTime;

    }

    private void Fire()
    {

        if(timer >= firecd) 
        { 

            spawnerPoints = spawner.position;

            var bullet = Instantiate(fireBall, spawnerPoints, new Quaternion(0, 0, 0, 0), null);

            Rigidbody2D rbbullet = bullet.GetComponent<Rigidbody2D>();

            if (right)
            {

                rbbullet.velocity = new Vector2(bulletSpeed, 0);

            }

            else
            {

                rbbullet.velocity = new Vector2(-bulletSpeed, 0);

            }

            timer = 0;

        }

    }

}
