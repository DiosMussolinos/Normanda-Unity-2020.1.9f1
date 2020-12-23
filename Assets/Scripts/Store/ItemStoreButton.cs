using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemStoreButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public int buttonID;
    public Item itemData;
    [SerializeField] private Item thisItem;
    
    //Get Image and Description
    public Image itemImage;
    public Text itemName;
    public Text itemDescription;

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
        if (thisItem != null)
        {
            //Ter imagem a mostra
            itemImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //Mudar de acordo com o item selecionado
            itemImage.sprite = thisItem.itemSprite;

            //Mudar Texto
            //Name
            itemName.GetComponent<Text>().text = thisItem.name;
            //Description
            itemDescription.GetComponent<Text>().text = thisItem.itemDes;
        }

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
