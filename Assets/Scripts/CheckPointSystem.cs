using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    
    public void CheckPoint()
    {

        GameObject.FindGameObjectWithTag("eva").GetComponent<Movement>().checkPoint = this.transform.position;

        Destroy(this.gameObject.transform.parent.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {

            CheckPoint();

        }

    }

}
