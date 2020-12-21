using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item itemData;

    private void Awake()
    {
        DontDestroyOnLoad(itemData);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Destroy(gameObject);

            GameManager.instance.AddItem(itemData);
        }
    }

}
