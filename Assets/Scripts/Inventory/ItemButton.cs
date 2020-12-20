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
            //Debug.Log("Enter " + thisItem.itemName);
            itemImage.sprite = thisItem.itemSprite;
        }
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if ((thisItem != null) && (thisItem.itemType == "Potion"))
        {
            GameManager.instance.RemoveItem(thisItem);
            SourceCode.lifePoints = SourceCode.lifePoints + thisItem.life;
        }
    }
}
