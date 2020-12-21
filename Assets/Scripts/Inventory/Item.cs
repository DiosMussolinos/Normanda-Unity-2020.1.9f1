using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{

    public string itemName;
    public string itemType;
    public string itemDes;

    public Sprite itemSprite;
    public int damage;
    public int shield;
    public int life;
    public int price;
    public int rarity;

    public bool usable;
}
