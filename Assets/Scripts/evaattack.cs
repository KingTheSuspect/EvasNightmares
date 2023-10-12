using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evaattack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask enemyLayers;
    float nextAttackTime;
    [SerializeField] private float attackRate;
    public int baseDamage = 10;


    private void Update()
    {
       //if(Time.time >= nextAttackTime)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        //}
    }

    void Attack()
    {

        anim.SetTrigger("hit");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {

            if (GameObject.Find("whimsy").GetComponent<whimsyfallow>().hatmode)
            {

                enemy.gameObject.GetComponent<EnemyHealthSystem>().GetDamageFromEvaWithWhimsy(baseDamage);

                Debug.Log("hatmode hit");

            }

            else
            {

                enemy.gameObject.GetComponent<EnemyHealthSystem>().GetDamageFromEva(baseDamage);

                Debug.Log("normal hit");

            }

        }

    }

}
