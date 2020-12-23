using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public static bool inventoryOpen = false;
    public GameObject inventoryUI;

    public List<Item> items = new List<Item>(); //LIST OF ITEMS WE HAVE
    public List<int> itemAmount = new List<int>(); //AMOUNT OF ITEMS PER ITEM

    public GameObject[] slots;

    //public Dictionary<Item, int> ItemDirectory = new Dictionary<Item, int>(); //Align The two lists

    public Item addItem_01;

    void Start() 
    {
        DisplayItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) 
        {
            AddItem(addItem_01);
        }


        if (Input.GetKeyDown(KeyCode.I)) 
        {

            if (inventoryOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
    }

    void OpenInventory()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        inventoryOpen = true;
    }

    void CloseInventory() 
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        inventoryOpen = false;
    }

    public void DisplayItems() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                //Update Inventory Slots
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //Update Slots Count Text - GET FUCKED, IM UNDERSTANDING THIS CODE
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemAmount[i].ToString();

            }
            else
            {
                //Update Inventory Slots
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update Slots Count Text - GET FUCKED, IM UNDERSTANDING THIS CODE
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(0, 0, 0, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;
            }
        }
    }

    public void AddItem(Item _item) 
    {
        //if there is one existing item in our bags (List)

        if (!items.Contains(_item)) 
        {
            items.Add(_item);
            itemAmount.Add(1);
        }
        else
        {
            Debug.Log("You Have already this One");
            for (int i = 0; i < items.Count; i++) 
            {
                if (_item == items[i]) 
                {
                    itemAmount[i]++;
                }
            }
        }
        DisplayItems();
    }

}
