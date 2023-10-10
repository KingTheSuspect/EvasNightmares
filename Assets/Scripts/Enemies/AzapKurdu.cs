using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzapKurdu : MonoBehaviour
{

    [SerializeField] private bool isSeeing = false;
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool right = true;
    [SerializeField] private Vector2 Scale;
    [SerializeField] private Transform point1, point2;
    [SerializeField] private bool done = false;
    [SerializeField] private bool stopcompletely = false;
    [SerializeField] private float animtime = 1f;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float maxDistance = 8f;
    [SerializeField] private bool isFollowing = false;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float followDistance = 5f;
    [SerializeField] private int damage = 10;
    [SerializeField] private int lifeSteal = 10;

    [SerializeField] private bool stop = false;
    [SerializeField] private bool stop1 = false;
    [SerializeField] private float waitformax = 5f, waitformin = 1f;
    [SerializeField] private Vector2 target;

    public GameObject[] friendInNeed;

    private void Start()
    {

        Scale = this.gameObject.transform.localScale;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        newTarget();

    }

    private void Update()
    {

        if (isSeeing && !done)
        {

            Call();

        }

    }

    public void FixedUpdate()
    {

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if(distance <= followDistance)
        {

            isFollowing = true;

        }

        if (!isFollowing)
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

            if (distance >= maxDistance)
            {

                isFollowing = false;

            }

            else if (distance <= attackDistance)
            {

                if (!stop1)
                {

                    StartCoroutine(Attack());

                }

            }

            if (isFollowing)
            {

                if (transform.position.x < playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
                {

                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    this.gameObject.transform.localScale = Scale;

                }

                else if (transform.position.x > playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
                {

                    this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    this.gameObject.transform.localScale = new Vector2(-Scale.x, Scale.y);

                }

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

            GameObject.FindGameObjectWithTag("Player").GetComponent<healtsystem>().GetDamage(damage);

            this.gameObject.GetComponent<EnemyHealthSystem>().health += lifeSteal;

        }

        stop1 = false;

    }

    private void Call()
    {

        done = true;

        foreach(GameObject enemy in friendInNeed)
        {

            if (enemy.name == "LostSoul")
            {

                enemy.GetComponent<LostSouls>().isAttacking = true;
                enemy.GetComponent<LostSouls>().isMoving = false;
                enemy.GetComponent<LostSouls>().destroyIt = 3.5f;

            }

            else if (enemy.name == "Guardian")
            {

                enemy.GetComponent<Guardian>().wolfDistance = 20;
                enemy.GetComponent<Guardian>().isFollowing = true;

            }

        }

    }

}
