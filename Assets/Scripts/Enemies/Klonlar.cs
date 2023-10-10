using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Klonlar : MonoBehaviour
{

    [SerializeField] private float speed = 3f, dashSpeed = 10f, jumpForce = 10f, attackRate = 1.5f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector2 Scale;
    [SerializeField] private int damage, attackDistance = 1;
    [SerializeField] private bool stop = false;

    void Start()
    {

        Scale = this.gameObject.transform.localScale;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        float distance = Vector2.Distance(playerTransform.position, transform.position);

        if(distance <= attackDistance && !stop)
        {

            Attack();

        }

        else if (distance > attackDistance)
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

    void Attack()
    {

        stop = true;

        if (transform.position.x < playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(dashSpeed, jumpForce);
            this.gameObject.transform.localScale = Scale;

        }

        else if (transform.position.x > playerTransform.position.x && !(Vector3.Distance(transform.position, playerTransform.position) < 1))
        {

            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-dashSpeed, jumpForce);
            this.gameObject.transform.localScale = new Vector2(-Scale.x, Scale.y);

        }

        GetComponent<Rigidbody2D>().gravityScale = 1;

        GameObject.Find("eva").GetComponent<healtsystem>().GetDamage(damage);

        this.gameObject.GetComponent<EnemyHealthSystem>().GetDamageFromEva(999);

    }

}
