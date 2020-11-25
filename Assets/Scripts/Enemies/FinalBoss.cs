using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    //Behavior
    public float speed;


    //Control of Attacks
    public float timeBtwAttacks;
    public float startTimeBtwAttacks;

    //Details of Enemy
    public float finalBossLife;
    public float attackDamage;
    public float projectileDamage;
    public float gold;
    public float experience;
    public float level;

    //Calling stuff
    public GameObject topDownAttacks;
    public GameObject sideAttacks;
    public Transform player;

    //Variables For Stages//Math//Behavior
    public float finalBossStage;
    public float finalBossLifeForMath;
    //public bool onLayr;


    // Awake is called before Start
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
     
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from Enemy and Player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Position of The Attacks
        Vector3 attackTop = new Vector3(transform.position.x, transform.position.y + 2.6f, transform.position.z);
        Vector3 attackBottom = new Vector3(transform.position.x, transform.position.y - 2.6f, transform.position.z);
        Vector3 attackLeft = new Vector3(transform.position.x - 2.6f, transform.position.y, transform.position.z);
        Vector3 attackRight = new Vector3(transform.position.x + 2.6f, transform.position.y, transform.position.z);

        //__BEHAVIOR__\\
        if (distance < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //__BEHAVIOR__\\

        //Timer && distance = Kill that mf
        if (timeBtwAttacks <= 0)
        {
            //Fazer ser child
            Instantiate(topDownAttacks, attackTop, Quaternion.identity);
            Instantiate(topDownAttacks, attackBottom, Quaternion.identity);
            Instantiate(sideAttacks, attackLeft, Quaternion.Euler(0,0,-90));
            Instantiate(sideAttacks, attackRight, Quaternion.Euler(0, 0, -90));

            timeBtwAttacks = startTimeBtwAttacks;
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }

        //Reset of the timer
        if (finalBossLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            finalBossLife = finalBossLife - 10;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            finalBossLife = finalBossLife - 20;
        }
    }
}
