using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumedSoul : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float minWaitTime = 1f;
    public float maxWaitTime = 3f;
    public float moveSpeed = 3f;
    public float followDistance = 5f;
    public bool isFollowing;
    public bool isAttacking;
    private Vector2 targetPoint;
    private Transform playerTransform;
    private float waitTime;
    private float timer;
    private Vector2 playerpoint;
    public int wolfDistance;
    public float attackTime;
    float time;
    bool animrightleftbool;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        print(isAttacking);
        float step = moveSpeed * Time.deltaTime;
        float distance = Vector2.Distance(this.transform.position, playerTransform.position);

        if(distance <= 5)
        {
            isFollowing = true;
            isAttacking = false;

        }

        if (distance >= 9)
        {
            isFollowing = false;
            isAttacking = false;

        }

        if (distance <= 0.6f)
        {
            isFollowing = false;
            isAttacking = true;
            moveSpeed = 0;
        }

        else
        {
            moveSpeed = 4;
        }


        if (isAttacking)
        {
            time += Time.deltaTime;
            moveSpeed = 0;
            if(time >= attackTime)
            {
                print("attack");
                animrightleftbool = !animrightleftbool;
                time = 0;
            }
        }

        else
        {
            moveSpeed = 4;
            time = 0;
        }





        if (isFollowing)
        {
            playerpoint = new Vector2(playerTransform.position.x, playerTransform.position.y);


            transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, playerpoint.x, step), transform.position.y);

            if (playerTransform.position.x > transform.position.x)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, targetPoint.x, step), transform.position.y);

            if (targetPoint.x > transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);

            }
            else
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);

            }
        }

        if (Mathf.Approximately(transform.position.x, targetPoint.x))
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                SetRandomTarget();
                SetRandomWaitTime();
                timer = 0f;
            }
        }




    }




  


    private void SetRandomTarget()
    {
        float randomX = Random.Range(Mathf.Min(pointA.position.x, pointB.position.x), Mathf.Max(pointA.position.x, pointB.position.x));
        float randomY = Random.Range(pointA.position.y, pointA.position.y + 2f);
        targetPoint = new Vector2(randomX, randomY);
    }

    private void SetRandomWaitTime()
    {
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }
}
