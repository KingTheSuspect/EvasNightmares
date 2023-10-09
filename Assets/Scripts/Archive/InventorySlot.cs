using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image image;
    public Text text;
    public int item = 0;
    public Color selectedColor, notSelectedColor;
    public InventoryManager im;

    public void Awake()
    {

        Deselect();

    }

    private void Update()
    {

        if (item == 0)
            text.text = im.healthPotionCount.ToString();
        else if (item == 1)
            text.text = im.damagePotionCount.ToString();
        else if (item == 2)
            text.text = im.shadowPotionCount.ToString();
        else if (item == 3)
            text.text = im.emotionBowlCount.ToString();
        else if (item == 4)
            text.text = im.bogaSerbetiCount.ToString();
        else if (item == 5)
            text.text = im.soulTransferCount.ToString();

    }

    public void Select()
    {

        image.color = selectedColor;

    }

    public void Deselect()
    {

        image.color = notSelectedColor;

    }

}
