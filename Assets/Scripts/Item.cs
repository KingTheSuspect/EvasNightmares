using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class Item : ScriptableObject
{

    public string id;
    public Sprite icon;
    public GameObject prefab;

}
