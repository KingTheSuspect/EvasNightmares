using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            collision.GetComponent<HealthSystem>().GetDamage(damage);

            Destroy(this.gameObject);

        }

    }

}
