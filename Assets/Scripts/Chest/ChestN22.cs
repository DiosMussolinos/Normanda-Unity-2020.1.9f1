using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestN22 : MonoBehaviour
{
    //Items ganhos obrigatórios
    public Item item1;
    public Item item2;
    public Item MapNextN;

    //Items ganhos Random
    public Item[] randomItems;
    private int randomIndex;

    //Transform do player
    public Transform player;

    //in range?
    public bool inRange;

    //Trocar imagem
    public SpriteRenderer sp;
    public Sprite open;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //SourceCode.chestN1 Pega Informação se ESSE bau ja foi aberto
        if (SourceCode.chestN22 == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && (inRange == true))
            {
                //primeira dice roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);
                //Segundo dice roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);
                //Terceiro dice Roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);
                //Quarto dice roll
                randomIndex = Random.Range(0, randomItems.Length);
                GameManager.instance.AddItem(randomItems[randomIndex]);

                //Dar items obrigatorios
                GameManager.instance.AddItem(item1);
                GameManager.instance.AddItem(item2);
                //mapa next Level
                GameManager.instance.AddItem(MapNextN);

                //não permitir repetição
                SourceCode.chestN22 = true;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
