using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//MARKER SINGLETON PATTERN
    public static bool inventoryOpen = false;
    public GameObject inventoryUI;

    public List<Item> items = new List<Item>(); //LIST OF ITEMS WE HAVE
    public List<int> itemAmount = new List<int>(); //AMOUNT OF ITEMS PER ITEM

    public GameObject[] slots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
       DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        DisplayItems();
    }

    void Update()
    {
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

                //Enable Button
                //slots[i].transform.GetChild(2).GetComponent<Button>().interactable = true;

            }
            else
            {
                //Update Inventory Slots
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update Slots Count Text - GET FUCKED, IM UNDERSTANDING THIS CODE
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(0, 0, 0, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //Disable Button
                //slots[i].transform.GetChild(2).GetComponent<Button>().interactable = false;
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
      
    public void RemoveItem(Item _item)
    {
       //if there is one existing item in our bags (List)

       if (items.Contains(_item))
       {
            for (int i = 0; i < items.Count; i++) 
            {
                if (_item == items[i]) 
                {

                    itemAmount[i]--;
                    if (itemAmount[i] == 0) 
                    {
                        items.Remove(_item);
                        itemAmount.Remove(itemAmount[i]);
                    }
                    
                }
            }
       } 
       DisplayItems();
    }
}
