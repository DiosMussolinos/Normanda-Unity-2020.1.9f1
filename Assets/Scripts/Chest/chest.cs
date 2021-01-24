using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    //Items ganhos obrigatórios
    public Item item1;
    public Item item2;
    
    //Items ganhos Random
    public Item[] randomItems;
    private int randomIndex;
    
    //Transform do player
    public Transform player;

    //in range?
    public bool inRange;
    //public Image pressToTalk;

    //Bau already oppened?
    private bool opened = false;

    //Trocar imagem
    public SpriteRenderer sp;
    public Sprite open;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        sp = gameObject.GetComponent<SpriteRenderer>();

        //pressToTalk.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (opened == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && (inRange == true))
            {
                //primeira dice roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);
                //Segundo dice roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);

                //Dar items obrigatorios
                GameManager.instance.AddItem(item1);
                GameManager.instance.AddItem(item2);

                //não permitir repetição
                opened = true;
            }
        }
        else
        {
            //TROCAR IMAGEM
            sp.sprite = open;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = true;
            //pressToTalk.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
            //pressToTalk.enabled = false;
        }
    }
}
