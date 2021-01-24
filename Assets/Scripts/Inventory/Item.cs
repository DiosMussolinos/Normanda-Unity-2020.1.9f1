using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public string ID;
    public string itemName;
    public string itemType;

    //Lore or whatever
    public string itemDes;
    public string lore;

    //Values
    public int damage;
    public int shield;
    public int life;
    public int price;

    //Sprite
    public Sprite itemSprite;
}
