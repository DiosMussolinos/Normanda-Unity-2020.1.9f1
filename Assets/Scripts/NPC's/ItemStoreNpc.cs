using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemStoreNpc : MonoBehaviour
{

    private ItemStoreNpc exist;

    private bool playerInRange = false;

    public static StoreManager instance;
    public static bool storeOpen = false;
    public GameObject storeUI;

    public List<Item> SeelItems = new List<Item>();

    public GameObject[] storeSlots;

    //Scene related
    private Scene scene;
    private string sceneName;

    private void Awake()
    {
        if (exist == null)
        {
            exist = this;
        }

        if (exist != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        DisplayStore();
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        if (sceneName != "N1")
        {
            gameObject.SetActive(false);
        }

        if (storeUI == null)
        {
            Destroy(gameObject);
        }

        if ((Input.GetKeyDown(KeyCode.E)) && (playerInRange == true))
        {
            if(storeOpen == false)
            {
                storeOpen = true;
            }
            else if (storeOpen == true)
            {
                storeOpen = false;
            }

            storeUI.SetActive(storeOpen);
        }
    }
    
    /*
    //MUDA MUDA MUDA MUDA MUDA MUDA -In Dio Brando Screams
    void OpenStore()
    {
        storeUI.SetActive(true);
        Time.timeScale = 0f;
        storeOpen = true;
    d
    }

    void CloseStore()
    {
        storeUI.SetActive(false);
        Time.timeScale = 1f;
        storeOpen = false;
    }
    */

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
