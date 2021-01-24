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
    [SerializeField] private Item SelectedItem;
   
    
    //Get Image and Description
    public Image itemImage;
    public Text itemName;
    public Text itemDescription;

    ///Text PopUp & Timer \\\\\\\\\\\\\ NOT WORKING FOR SOME WTF REASON -- will take care of it later
    private float confirmationCD = 5f;
    private float confirmation = 0;
    public Image PopUp;
    public Text PopUpText;

    void Start()
    {
        itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        PopUpText.GetComponent<Text>();
    }

    /*
    void Update()
    {
        if (confirmation >= 0) 
        {
            PopUp.gameObject.SetActive(true);
            confirmation -= Time.deltaTime;
        }
        
        if(confirmation < 0)
        {
            PopUp.gameObject.SetActive(false);
        }
    }
    */
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
         
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if ((thisItem != null) && (SourceCode.playerGold >= thisItem.price))
        {
            SelectedItem = thisItem;

            //Ter imagem a mostra
            itemImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //Mudar de acordo com o item selecionado
            itemImage.sprite = SelectedItem.itemSprite;

            //Mudar Texto
            //Name
            itemName.GetComponent<Text>().text = SelectedItem.itemName;
            //Description
            itemDescription.GetComponent<Text>().text = SelectedItem.itemDes;
        }

        if(SourceCode.playerGold < SelectedItem.price) 
        {
            itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }

    public void ConfirmPurchare()
    {
        if ((SelectedItem != null) && (SourceCode.playerGold >= SelectedItem.price))
        {
            //Pick the money, give the item
            SourceCode.playerGold -= SelectedItem.price;
            GameManager.instance.AddItem(SelectedItem);

            /*
            //Open PopUP
            confirmation = confirmationCD;
            PopUpText.text = "You just bought " + SelectedItem.name;
            */

            //Restart SelectedItem
            SelectedItem = null;
            itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }

}