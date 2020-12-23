using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemStoreButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public int buttonID;
    public Item itemData;
    [SerializeField] private Item thisItem;


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
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if ((thisItem != null) && (SourceCode.playerGold >= thisItem.price))
        {
            SourceCode.playerGold -= thisItem.price;
            GameManager.instance.AddItem(thisItem);
        }
    }
}
