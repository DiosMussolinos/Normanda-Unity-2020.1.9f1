using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public int soldierLife;

    //Calling stuff
    public GameObject SoldierAttack;
    public Transform player;
    private float soldierScale;
    private SpriteRenderer spriteRender;
    private Rigidbody2D rb;
    private Animator animator;

    // Awake is called before Start
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        //Find Player
        player = GameObject.FindWithTag("Player").transform;
        //Algum dia eu lembro o que é isso - Gabriel - 13/12/2020
        soldierScale = (transform.localScale.x / 2) + 1f;
        //Fazer o flip
        spriteRender = GetComponent<SpriteRenderer>();
        //Controle de animação
        animator = GetComponent<Animator>();
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
        Vector3 negativeSpawAttack = new Vector3(transform.position.x - 0.85f, transform.position.y, transform.position.z);
        Vector3 positiveSpawAttack = new Vector3(transform.position.x + 0.85f, transform.position.y, transform.position.z);
        
        //Distance From The player in the X to Flip    
        float distanceXFromPlayer = transform.position.x - player.transform.position.x;

        if (soldierLife > 0)
        {
            //__BEHAVIOR__\\
            if (distance < SourceCode.soldierVisionDistance && distance > 2)
            {

                //Animation
                animator.SetBool("Walk", true);

                transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.soldierSpeed * Time.deltaTime);
            } 
            else
            {
                //Animation
                animator.SetBool("Walk", false);
            }

            //Timer && distance = Kill that mf
            if ((SourceCode.timeBtwAttacks <= 0) && (distance <= SourceCode.soldierVisionDistance))
            {
                //Animation
                animator.SetBool("Attack", true);

                //Fazer ser child
                Instantiate(SoldierAttack, negativeSpawAttack, Quaternion.identity);
                Instantiate(SoldierAttack, positiveSpawAttack, Quaternion.identity);
                SourceCode.timeBtwAttacks = SourceCode.startTimeBtwAttacks;
            }
            else
            {
                SourceCode.timeBtwAttacks -= Time.deltaTime;
                //Animation
                animator.SetBool("Attack", false);
            }

            if (distanceXFromPlayer > 0)
            {

                //Turn around
                spriteRender.flipX = true;

            }
            else 
            {
                //Turn around
                spriteRender.flipX = false;
            }

        }


        //Reset of the timer
        if (soldierLife <= 0)
        {
            
            SourceCode.playerGold = SourceCode.playerGold + SourceCode.soldierGold;
            SourceCode.playerExp = SourceCode.playerExp + SourceCode.soldierExp;
            Destroy(gameObject);

            /*
            if (challenge = true) 
            {

                post.enemykilled + 1;

            }
            */
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            soldierLife = soldierLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            soldierLife = soldierLife - SourceCode.strongAttackDMG;
        }
    }

    /*
     ⡆⣐⢕⢕⢕⢕⢕⢕⢕⢕⠅⢗⢕⢕⢕⢕⢕⢕⢕⠕⠕⢕⢕⢕⢕⢕⢕⢕⢕⢕
  ⢐⢕⢕⢕⢕⢕⣕⢕⢕⠕⠁⢕⢕⢕⢕⢕⢕⢕⢕⠅⡄⢕⢕⢕⢕⢕⢕⢕⢕⢕
  ⢕⢕⢕⢕⢕⠅⢗⢕⠕⣠⠄⣗⢕⢕⠕⢕⢕⢕⠕⢠⣿⠐⢕⢕⢕⠑⢕⢕⠵⢕
  ⢕⢕⢕⢕⠁⢜⠕⢁⣴⣿⡇⢓⢕⢵⢐⢕⢕⠕⢁⣾⢿⣧⠑⢕⢕⠄⢑⢕⠅⢕
  ⢕⢕⠵⢁⠔⢁⣤⣤⣶⣶⣶⡐⣕⢽⠐⢕⠕⣡⣾⣶⣶⣶⣤⡁⢓⢕⠄⢑⢅⢑
  ⠍⣧⠄⣶⣾⣿⣿⣿⣿⣿⣿⣷⣔⢕⢄⢡⣾⣿⣿⣿⣿⣿⣿⣿⣦⡑⢕⢤⠱⢐
  ⢠⢕⠅⣾⣿⠋⢿⣿⣿⣿⠉⣿⣿⣷⣦⣶⣽⣿⣿⠈⣿⣿⣿⣿⠏⢹⣷⣷⡅⢐
  ⣔⢕⢥⢻⣿⡀⠈⠛⠛⠁⢠⣿⣿⣿⣿⣿⣿⣿⣿⡀⠈⠛⠛⠁⠄⣼⣿⣿⡇⢔
  ⢕⢕⢽⢸⢟⢟⢖⢖⢤⣶⡟⢻⣿⡿⠻⣿⣿⡟⢀⣿⣦⢤⢤⢔⢞⢿⢿⣿⠁⢕
  ⢕⢕⠅⣐⢕⢕⢕⢕⢕⣿⣿⡄⠛⢀⣦⠈⠛⢁⣼⣿⢗⢕⢕⢕⢕⢕⢕⡏⣘⢕
  ⢕⢕⠅⢓⣕⣕⣕⣕⣵⣿⣿⣿⣾⣿⣿⣿⣿⣿⣿⣿⣷⣕⢕⢕⢕⢕⡵⢀⢕⢕
  ⢑⢕⠃⡈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢃⢕⢕⢕
  ⣆⢕⠄⢱⣄⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⢁⢕⢕⠕⢁
  ⣿⣦⡀⣿⣿⣷⣶⣬⣍⣛⣛⣛⡛⠿⠿⠿⠛⠛⢛⣛⣉⣭⣤⣂⢜⠕⢑⣡⣴⣿
    CODE OPTIMIZATION DONE WITH PAIN
     */

}
