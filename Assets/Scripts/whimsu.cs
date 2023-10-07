using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whimsu : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2f;
    public float randomMoveRadius = 1f;
    public float orbitSpeed = 2f;
    public static bool isRandomMoving;
    public float randomMoveInterval = 2f;

    private Vector3 initialOffset;
    private Vector3 randomTargetPosition;
    private float timer;
    private float groundY;

    private void Start()
    {
        player = GameObject.Find("eva").transform;

        initialOffset = transform.position - player.position;
        randomTargetPosition = GetRandomPositionNearPlayer();
    }

    private void Update()
    {
        groundY = player.position.y;

        if (isRandomMoving)
        {
            RandomMove();
            followDistance = 20;
            
        }
        else
        {
            FollowPlayer();
            followDistance = 5;

        }
    }

    private void RandomMove()
    {

        timer += Time.deltaTime;
        if (timer >= randomMoveInterval)
        {
            randomTargetPosition = GetRandomPositionNearPlayer();
            timer = 0f;
        }


        transform.position = Vector3.Lerp(transform.position, randomTargetPosition, Time.deltaTime * orbitSpeed);


        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, groundY), transform.position.z);
    }

    private void FollowPlayer()
    {

        Vector3 desiredPosition = player.position + initialOffset;
        Vector3 direction = desiredPosition - player.position;
        Vector3 followPosition = player.position + direction.normalized * followDistance;
        transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime * orbitSpeed);


        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, groundY), transform.position.z);
    }

    private Vector3 GetRandomPositionNearPlayer()
    {

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 randomPosition = player.position + (Vector3)randomDirection * Random.Range(followDistance, followDistance + randomMoveRadius);
        return new Vector3(randomPosition.x, randomPosition.y, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (isRandomMoving)
        {
            randomTargetPosition = GetRandomPositionNearPlayer();
        }
    } 
}
