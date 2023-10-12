using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public GameObject[] Slots;

    private GameObject eva;

    public int selectedSlot = 0;

    public int healthPotionCount = 0;
    public int healthPercentage = 20;

    public int damagePotionCount = 0;
    public int damagePercentage = 10;

    public int shadowPotionCount = 0;
    public int shadowDuringTime = 3;

    public int emotionBowlCount = 0;
    public int healthPercentageBowl = 40;

    public int bogaSerbetiCount = 0;
    public int damagePercentageSerbet = 20;

    public int soulTransferCount = 0;
    public int shadowDuringTimeSoulTransfer = 6;

    private void Start()
    {

        eva = GameObject.Find("eva");

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) { DeselectAll(); selectedSlot = 0; }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { DeselectAll(); selectedSlot = 1; }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { DeselectAll(); selectedSlot = 2; }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { DeselectAll(); selectedSlot = 3; }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { DeselectAll(); selectedSlot = 4; }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) { DeselectAll(); selectedSlot = 5; }

        Slots[selectedSlot].GetComponent<InventorySlot>().Select();

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (selectedSlot == 0 && healthPotionCount > 0)
            {

                eva.GetComponent<healtsystem>().health += (eva.GetComponent<healtsystem>().maxHealth / 100) * healthPercentage;

                healthPotionCount -= 1;

            }

            else if (selectedSlot == 1 && damagePotionCount > 0)
            {

                eva.GetComponent<evaattack>().baseDamage += (eva.GetComponent<evaattack>().baseDamage / 100) * damagePercentage;

                damagePotionCount -= 1;

            }

            else if (selectedSlot == 2 && shadowPotionCount > 0)
            {

                StartCoroutine(beInvicible(shadowDuringTime));

                shadowPotionCount -= 1;

            }

            else if (selectedSlot == 3 && emotionBowlCount > 0)
            {

                eva.GetComponent<healtsystem>().health += (eva.GetComponent<healtsystem>().maxHealth / 100) * healthPercentageBowl;

                emotionBowlCount -= 1;

            }

            else if (selectedSlot == 4 && bogaSerbetiCount > 0)
            {

                eva.GetComponent<evaattack>().baseDamage += (eva.GetComponent<evaattack>().baseDamage / 100) * damagePercentageSerbet;

                bogaSerbetiCount -= 1;

            }

            else if (selectedSlot == 5 && soulTransferCount > 0)
            {

                StartCoroutine(beInvicible(shadowDuringTimeSoulTransfer));

                soulTransferCount -= 1;

            }

        }

    }

    void DeselectAll()
    {

        Slots[0].GetComponent<InventorySlot>().Deselect();
        Slots[1].GetComponent<InventorySlot>().Deselect();
        Slots[2].GetComponent<InventorySlot>().Deselect();
        Slots[3].GetComponent<InventorySlot>().Deselect();
        Slots[4].GetComponent<InventorySlot>().Deselect();
        Slots[5].GetComponent<InventorySlot>().Deselect();

    }

    IEnumerator beInvicible(int waitTime)
    {

        eva.GetComponent<PlayerController>().invicible = true;

        yield return new WaitForSeconds(waitTime);

        eva.GetComponent<PlayerController>().invicible = false;

    }

}
