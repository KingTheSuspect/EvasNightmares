using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torturer : MonoBehaviour
{
    public Transform playerTransform;
    float time;
    public float attackTime;
    public Transform targetPosition;
    public bool attack;
    public float realAttackDamage;
    public float nowHealth;
    public Collider2D col2D;
    float attackTimer;
    bool inside;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        targetPosition = GameObject.FindGameObjectWithTag("torturerTargetPoint").transform; 
    }

    void Update()
    {
        time += Time.deltaTime;


        if (time >= attackTime ) 
        {
            attack = true;

        }

        else if(time >= attackTime)
        {
            time = 0;
        }

     

        if (attack)
        {
            attackTimer += Time.deltaTime;
            time = 0;
        }

        else
        {
            attackTimer = 0;
        }

        if (attackTimer >= 0.1f)
        {
            attack = false;

        }

       
        if (col2D != null)
        {
            Vector2 currentOffset = col2D.offset;
            if (attack)
            {
                currentOffset.y = 0;
            }

            else
            {
                currentOffset.y = 2;
            }



            col2D.offset = currentOffset;

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && attack == true)
        {
            nowHealth = collision.GetComponent<HealthSystem>().health;

            if (nowHealth > 80)
            {
                float realDamage = nowHealth / 5;
                realAttackDamage = Mathf.RoundToInt(realDamage);

            }

            if (nowHealth <= 80)
            {
                float realDamage = nowHealth / 4;
                realAttackDamage = Mathf.RoundToInt(realDamage);

            }

            else if (nowHealth <= 55)
            {
                float realDamage = nowHealth / 2.5f;
                realAttackDamage = Mathf.RoundToInt(realDamage);

            }


            else if (nowHealth <= 30)
            {

                float realDamage = nowHealth / 1.8f;
                realAttackDamage = Mathf.RoundToInt(realDamage);

            }

            else if (nowHealth <= 20)
            {

                realAttackDamage = 9999;

            }

            playerTransform.position = new Vector2(targetPosition.position.x, targetPosition.position.y);
            GameObject.Find("eva").GetComponent<HealthSystem>().health -= realAttackDamage;
            attack = false;
            time = 0;
        }
        if (collision.gameObject.tag == "Player")
        {
            inside = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inside = false;
    }


}
