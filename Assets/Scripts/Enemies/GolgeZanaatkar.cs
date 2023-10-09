using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolgeZanaatkar : MonoBehaviour
{

    public float speed = 3f;
    public bool right = true;
    public Vector2 Scale;
    public Transform point1, point2;
    public bool done = false;
    public bool stopcompletely = false;
    private Transform playerTransform;

    public bool startCloning = false;
    public float cloningDistance = 6f;
    public int damage = 10;
    public bool attack = false;
    public float attackDistance = 2f;

    public bool stop = false;
    public bool stop1 = false;
    public float waitformax = 5f, waitformin = 1f;
    public Vector2 target;

    public GameObject Klon;

    private void Start()
    {

        Scale = this.gameObject.transform.localScale;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        newTarget();

    }

    private void Update()
    {

        if (startCloning && !done)
        {

            StartCoroutine(Clone());

        }

    }

    public void FixedUpdate()
    {

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if (distance <= attackDistance)
        {

            attack = true;
            startCloning = false;

        }

        else if (distance <= cloningDistance)
        {

            startCloning = true;
            attack = false;

        }

        else
        {

            startCloning = false;
            attack = false;

        }

        if (!attack && !startCloning)
        {

            if (transform.position.x < target.x && !(Vector3.Distance(transform.position, target) < 1))
            {

                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                this.gameObject.transform.localScale = Scale;

            }

            else if (transform.position.x > target.x && !(Vector3.Distance(transform.position, target) < 1))
            {

                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                this.gameObject.transform.localScale = new Vector2(-Scale.x, Scale.y);

            }

            else if (Vector3.Distance(transform.position, target) < 1)
            {

                if (!stop)
                {

                    StartCoroutine(waitrandomly());

                }

                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            }

        }

        else
        {

            if (distance >= cloningDistance)
            {

                startCloning = false;

            }

            else if (attack)
            {

                if (!stop1)
                {

                    StartCoroutine(Attack());

                }

            }

            if (transform.position.x < playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
            {

                this.gameObject.transform.localScale = Scale;

            }

            else if (transform.position.x > playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
            {

                this.gameObject.transform.localScale = new Vector2(-Scale.x, Scale.y);

            }

        }

    }

    private void newTarget()
    {

        target = new Vector2(Random.Range(point1.position.x, point2.position.x), this.gameObject.transform.position.y);

    }

    IEnumerator waitrandomly()
    {

        stop = true;

        yield return new WaitForSeconds(Random.Range(waitformin, waitformax));

        newTarget();

        stop = false;

    }

    IEnumerator Attack()
    {

        stop1 = true;

        yield return new WaitForSeconds(0.5f);

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if (distance <= attackDistance)
        {

            GameObject.Find("eva").GetComponent<healtsystem>().GetDamage(damage);

        }

        yield return new WaitForSeconds(0.1f);

        if (distance <= attackDistance)
        {

            GameObject.Find("eva").GetComponent<healtsystem>().GetDamage(damage);

        }
        
        yield return new WaitForSeconds(0.1f);

        if (distance <= attackDistance)
        {

            GameObject.Find("eva").GetComponent<healtsystem>().GetDamage(damage);

        }

        stop1 = false;

    }

    IEnumerator Clone()
    {

        done = true;

        yield return new WaitForSeconds(1f);

        Instantiate(Klon, this.gameObject.transform.position, new Quaternion(0, 0, 0, 0), null);

        done = false;

    }

}
