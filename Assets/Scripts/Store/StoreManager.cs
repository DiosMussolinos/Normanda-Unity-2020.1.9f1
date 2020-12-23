using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;
    public static bool storeOpen = false;
    public GameObject storeUI;

    public List<Item> SeelItems = new List<Item>();

    public GameObject[] storeSlots;


    /*
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
    }*/

    void Start()
    {
        DisplayStore();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && (storeOpen = false))
        {
            storeUI.SetActive(true);
            Time.timeScale = 0f;
            storeOpen = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (storeOpen = true))
        {
            storeUI.SetActive(false);
            Time.timeScale = 1f;
            storeOpen = false;
        }

    }

    void OpenStore() 
    {
        storeUI.SetActive(true);
        Time.timeScale = 0f;
        storeOpen = true;

    }

    void CloseStore()
    {
        storeUI.SetActive(false);
        Time.timeScale = 1f;
        storeOpen = false;
    }

    public void DisplayStore() 
    {
        for (int i = 0; i < SeelItems.Count; i++)
        {
                //Update Store Images
                storeSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                storeSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = SeelItems[i].itemSprite;

                //Update Slots Count Text - GET FUCKED, IM UNDERSTANDING THIS CODE
                storeSlots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                storeSlots[i].transform.GetChild(1).GetComponent<Text>().text = SeelItems[i].price.ToString();
        }
    }
}
