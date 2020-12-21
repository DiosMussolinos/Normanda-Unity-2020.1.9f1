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

    public Image itemOn1;
    public Image itemOn2;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Start() 
    {
        itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        itemOn1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        itemOn2.GetComponent<Image>().color = new Color(0, 0, 0, 0);
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
            //Ter imagem a mostra
            itemImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //Mudar de acordo com o item selecionado
            itemImage.sprite = thisItem.itemSprite;
        }
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        GetThisItem();
        if ((thisItem != null) && (thisItem.itemType == "Potion"))
        {
            //Remover da lista
            GameManager.instance.RemoveItem(thisItem);
            //Aumentar a vida baseada no valor do item
            SourceCode.lifePoints += thisItem.life;
        }

        if ((thisItem != null) && (thisItem.itemType == "Sword"))
        {
            //Reiniciar os valores
            SourceCode.basicAttackDMG = 10;
            SourceCode.strongAttackDMG = 20;
            //Somar com os valores originais
            SourceCode.basicAttackDMG += thisItem.damage;
            SourceCode.strongAttackDMG += thisItem.damage;

            //Ter imagem a mostra
            itemOn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //Mudar de acordo com o item selecionado
            itemOn1.sprite = thisItem.itemSprite;
        }
        
        if ((thisItem != null) && (thisItem.itemType == "Shield"))
        {
            //Reiniciar os valores
            SourceCode.percentageDefense = 0;
            //Somar com os valores originais
            SourceCode.percentageDefense += thisItem.shield;

            //Ter imagem a mostra
            itemOn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //Mudar de acordo com o item selecionado
            itemOn2.sprite = thisItem.itemSprite;
        }
        
    }
}
