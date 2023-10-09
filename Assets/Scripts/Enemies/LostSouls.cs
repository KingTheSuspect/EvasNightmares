using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostSouls : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackSpeed = 5f;
    public float randomMoveInterval = 3f; 
    public float detectionRange = 5f;
    public float speed;
    public float destroyIt = 2.5f;

    public bool isAttacking = false;
    public bool isMoving = false;
    private float timeSinceLastRandomMove = 0f;
    private Vector3 randomTargetPosition;
    bool attackingNow;
    GameObject eva;
    float destroyTime;

    float timer;
    public float timerInterval;
    private void Start()
    {
        isMoving = true;
        isAttacking = false;
        SetRandomTargetPosition();
        eva = GameObject.Find("eva");
        player = GameObject.Find("eva").transform;
    }

    private void Update()
    {
            if (destroyTime >= destroyIt)
            {
                Destroy(transform.parent.gameObject);
            }

            timer += Time.deltaTime;
            if (isMoving)
            {
                HandleMoving();
            }
            else if (isAttacking)
            {
                MoveToPlayer();
                destroyTime += Time.deltaTime;
            }


            if (attackingNow)
            {
                eva.GetComponent<Movement>().jumpForce = 0;
                eva.GetComponent<Movement>().speed = 0;
                eva.GetComponent<Movement>().isdead = true;

                if (timer >= timerInterval)
                {
                    eva.GetComponent<healtsystem>().health--;
                    timer = 0f;
                }
                destroyTime = -99999;
            }
    }

    private void HandleMoving()
    {
        timeSinceLastRandomMove += Time.deltaTime;

        if (timeSinceLastRandomMove >= randomMoveInterval)
        {
            SetRandomTargetPosition();
            timeSinceLastRandomMove = 0f;
        }

        MoveTowardsTargetPosition();

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            StartAttack();
        }
    }

    private void SetRandomTargetPosition()
    {
        randomTargetPosition = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));
        
    }

    private void MoveTowardsTargetPosition()
    {
        Vector3 directionToTarget = (randomTargetPosition - transform.position).normalized;
        Vector3 moveTowardsTarget = transform.position + directionToTarget * speed * Time.deltaTime;
        transform.position = moveTowardsTarget;
        speed = moveSpeed;
    }

    private void MoveToPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 moveTowardsPlayer = transform.position + directionToPlayer * speed * Time.deltaTime;
        transform.position = moveTowardsPlayer;
        speed = attackSpeed;
    }

    public void StartAttack()
    {
        isMoving = false;
        isAttacking = true;
    }

    public void StopAttack()
    {
        isMoving = true;
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            attackingNow = true;
        }
    }
}
