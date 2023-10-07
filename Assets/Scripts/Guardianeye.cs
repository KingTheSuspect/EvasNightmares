using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardianeye : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("Guardian").GetComponent<Guardian>().isFollowing = true;
        }
    }

}
