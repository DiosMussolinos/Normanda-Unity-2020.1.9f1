using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStoreNpc : MonoBehaviour
{

    public bool playerInRange = false;

    public static StoreManager instance;
    public static bool storeOpen = false;
    public GameObject storeUI;

    public List<Item> SeelItems = new List<Item>();

    public GameObject[] storeSlots;

    private void Awake()
    {
        
    }

    void Start()
    {
        DisplayStore();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && (playerInRange == true))
        {

            if (storeUI.activeInHierarchy)
            {
                storeUI.SetActive(true);
                storeOpen = true;
            }
            else
            {
                storeUI.SetActive(false);
                storeOpen = false;
            }
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

            //Update Slots Count Text
            storeSlots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            storeSlots[i].transform.GetChild(1).GetComponent<Text>().text = SeelItems[i].price.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            //Npc Stop
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //Npc walks
            playerInRange = false;
            //Joke off
            storeUI.SetActive(false);

        }
    }

}
