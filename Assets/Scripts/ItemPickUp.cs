using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public int item = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player") 
        {

            if (item == 0)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().healthPotionCount += 1;
            else if (item == 1)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().damagePotionCount += 1;
            else if (item == 2)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().shadowPotionCount += 1;
            else if (item == 3)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().emotionBowlCount += 1;
            else if (item == 4)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().bogaSerbetiCount += 1;
            else if (item == 5)
                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().soulTransferCount += 1;

            Destroy(this.gameObject);

        }

    }

}
