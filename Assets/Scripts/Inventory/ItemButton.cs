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

    //Player
    private GameObject player;
    private ActiveItems ActiveItems;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ActiveItems = player.GetComponent<ActiveItems>();
    }

    void Start() 
    {
        itemImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        itemOn1.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        itemOn2.GetComponent<Image>().color = new Color(0, 0, 0, 0);

        if (ActiveItems.Items[0] != null) {

            itemOn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            itemOn1.sprite = ActiveItems.Items[0].itemSprite;

        }
        if (ActiveItems.Items[1] != null) {

            itemOn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            itemOn2.sprite = ActiveItems.Items[1].itemSprite;
            SourceCode.percentageDefense = ActiveItems.Items[1].shield;
        }
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

            //Definir Item[0] como espada que esta carregando
            ActiveItems.Items[0] = thisItem;

            //Somar com os valores originais
            SourceCode.basicAttackDMG += ActiveItems.Items[0].damage;
            SourceCode.strongAttackDMG += ActiveItems.Items[0].damage;

            //Ter imagem a mostra
            itemOn1.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            //Mudar de acordo com o item selecionado
            itemOn1.sprite = thisItem.itemSprite;
        }
        
        if ((thisItem != null) && (thisItem.itemType == "Shield"))
        {
            //Reiniciar os valores
            SourceCode.percentageDefense = 0;

            //Definir Item[1] como escudo que esta carregando
            ActiveItems.Items[1] = thisItem;

            //Somar com os valores originais
            SourceCode.percentageDefense += ActiveItems.Items[1].shield;

            //Ter imagem a mostra
            itemOn2.GetComponent<Image>().color = new Color(1, 1, 1, 1);

            //Mudar de acordo com o item selecionado
            itemOn2.sprite = thisItem.itemSprite;
        }
        
    }
}
