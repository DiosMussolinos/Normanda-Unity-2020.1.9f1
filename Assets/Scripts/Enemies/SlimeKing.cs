using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKing : MonoBehaviour
{

    public int slimeLife;

    //Calling stuff
    public GameObject projectile;
    public Transform player;
    private SpriteRenderer spriteRender;
    private Animator animator;


    public float timeBtwAttacks;
    public float startTimeBtwAttacks;

    // Awake is called before Start
    void Awake()
    {
        //Find Player Position
        player = GameObject.FindWithTag("Player").transform;

        //Find Component
        spriteRender = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from Enemy and Player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Distance From The player in the X to Flip    
        float distanceXFromPlayer = transform.position.x - player.transform.position.x;


        ////////////////////////__BEHAVIOR__\\\\\\\\\\\\\\\\\\\\\\\\
        if (distance > SourceCode.slimeStoppingDistance)
        {
            transform.position = this.transform.position;

            animator.SetBool("Walk", false);

        }
        if (distance < SourceCode.slimeRetreaDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -SourceCode.slimeSpeed * Time.deltaTime);

            animator.SetBool("Walk", true);
        }
        ////////////////////////__BEHAVIOR__\\\\\\\\\\\\\\\\\\\\\\\\


        if (distanceXFromPlayer > 0)
        {
            //Turn around
            spriteRender.flipX = true;

            if ((startTimeBtwAttacks <= 0) && (distance <= SourceCode.slimeVisionDistance))
            {
                //Create Shot
                Instantiate(projectile, new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z), Quaternion.identity);
                //RestartTimer
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                //RestartTheCountDown
                timeBtwAttacks -= Time.deltaTime;
            }
        }

        if (distanceXFromPlayer < 0)
        {
            //Turn around
            spriteRender.flipX = false;

            if ((timeBtwAttacks <= 0) && (distance <= SourceCode.slimeVisionDistance))
            {
                //Create Shot
                Instantiate(projectile, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z), Quaternion.identity);
                //RestartTimer
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                //RestartTheCountDown
                timeBtwAttacks -= Time.deltaTime;
            }
        }

        //Death
        if (slimeLife <= 0)
        {
            //Giving EXP
            SourceCode.playerExp = SourceCode.playerExp + SourceCode.slimeExp;
            //Giving Gold
            SourceCode.playerGold = SourceCode.playerGold + SourceCode.slimeGold;
            //Suicide
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            //Recieve DMG BasicAttack
            slimeLife = slimeLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            //Recieve DMG Strong
            slimeLife = slimeLife - SourceCode.strongAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("Shot"))
        {
            //Recieve DMG Strong
            slimeLife = slimeLife - SourceCode.slimeProjectileDamage;
        }

    }
}