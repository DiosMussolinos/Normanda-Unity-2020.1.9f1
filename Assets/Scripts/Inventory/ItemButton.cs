using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public int buttonID;
    public Item itemData;
    [SerializeField] private Item thisItem;
    //public Sprite itemImage;
    public Image itemImage;

    void Start() 
    {
        itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
    }

    private Item GetThisItem() 
    {

        for (int i = 0; i < GameManager.instance.items.Count; i++) 
        {
            if (buttonID == i) 
            {
                thisItem = GameManager.instance.items[i];
            }
        }
        return thisItem;
    }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();
        if(thisItem != null) 
        {
            itemImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            
            itemImage.sprite = thisItem.itemSprite;
        }
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if ((thisItem != null) && (thisItem.itemType == "Potion"))
        {
            GameManager.instance.RemoveItem(thisItem);
            SourceCode.lifePoints += thisItem.life;
        }

        if ((thisItem != null) && (thisItem.itemType == "Sword"))
        {
            SourceCode.basicAttackDMG = 10;
            SourceCode.strongAttackDMG = 20;
            //GameManager.instance.RemoveItem(thisItem);
            SourceCode.basicAttackDMG += thisItem.damage;
            SourceCode.strongAttackDMG += thisItem.damage;
            //SourceCode.basicAttackDMG += SourceCode.ItemValues[0]; 
        }
        
        if ((thisItem != null) && (thisItem.itemType == "Shields"))
        {
            SourceCode.percentageDefense = 0;
            SourceCode.percentageDefense += thisItem.shield;
        }
        
    }
}
