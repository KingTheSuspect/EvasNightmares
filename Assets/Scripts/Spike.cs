using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    public int damage = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            collision.gameObject.transform.position = collision.gameObject.GetComponent<Movement>().checkPoint;

            collision.gameObject.GetComponent<healtsystem>().GetDamage(damage);

        }

    }

}
