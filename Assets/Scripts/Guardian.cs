using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB; 
    public float minWaitTime = 1f; 
    public float maxWaitTime = 3f; 
    public float moveSpeed = 3f;
    public float followDistance = 5f; 
    public bool isFollowing;
    public float turnSpeed = 5f;
    public bool isAttacking;

    private Vector2 targetPoint;
    private Transform playerTransform;
    private float waitTime;
    private float timer;
    private Vector2 playerpoint;
    float attackTimer;
    public float timeAttack;
    bool attack;
    public int damage;
    public GameObject attackPoint;
    public BoxCollider2D col2D;
    public float eyeDistance;
    public int wolfDistance;
    

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SetRandomTarget();
        SetRandomWaitTime();
    }

    private void Update()
    {
        


        if (col2D != null)
        {
            Vector2 currentOffset = col2D.offset;
            if (attack)
            {
                currentOffset.x = 1;
            }

            else
            {
                currentOffset.x = 0;
            }



            col2D.offset = currentOffset;

        }


        float step = moveSpeed * Time.deltaTime;
        float distance = Vector2.Distance(playerTransform.position, transform.position);
        if(distance >= wolfDistance)
        {
            isFollowing = false;
        }
        if (distance <= followDistance)
        {
            isAttacking = true;
        }

        else
        {
            isAttacking = false;
        }

        if (isAttacking)
        {
            Attack();
            moveSpeed = 0;
        }

        else
        {
            moveSpeed = 2;
        }



        if (isFollowing)
        {
            playerpoint = new Vector2(playerTransform.position.x, playerTransform.position.y);

            /*float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);*/

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
     
    public void StopFollowing()
    {
        isFollowing = false;
        attackTimer = 0;
    }

    public void Attack()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer >= timeAttack)
        {
            attack = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && attack)
        {
           
            attack = false;
            GameObject.Find("eva").GetComponent<healtsystem>().GetDamage(damage);
            attackTimer = 0;
            moveSpeed = 2;
        }
    }
}
