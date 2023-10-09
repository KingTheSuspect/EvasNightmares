using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour
{

    public int health = 10;

    public int item = 0;

    public void useIt()
    {

        if (item == 0 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().healthPotionCount > 0)
        {

            if (GameObject.Find("eva").GetComponent<healtsystem>().health < 100)
            {

                GameObject.Find("eva").GetComponent<healtsystem>().health += health;

                GameObject.Find("InventoryManager").GetComponent<InventoryManager>().healthPotionCount -= 1;

            }

        }
            
        else if (item == 1 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().damagePotionCount > 0)
        {

            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().damagePotionCount -= 1;

        }
            
        else if (item == 2 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().shadowPotionCount > 0)
        {

            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().shadowPotionCount -= 1;

        }
            
        else if (item == 3 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().emotionBowlCount > 0)
        {

            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().emotionBowlCount -= 1;

        }
            
        else if (item == 4 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().bogaSerbetiCount > 0)
        {

            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().bogaSerbetiCount -= 1;

        }
            
        else if (item == 5 && GameObject.Find("InventoryManager").GetComponent<InventoryManager>().soulTransferCount > 0)
        {

            GameObject.Find("InventoryManager").GetComponent<InventoryManager>().soulTransferCount -= 1;

        }
            

        

    }

}
