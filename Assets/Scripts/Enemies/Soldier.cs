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
    private Rigidbody2D rb;
    private Animator animator;

    // Awake is called before Start
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        soldierScale = (transform.localScale.x / 2) + 1f;
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


        if (soldierLife > 0)
        {
            //__BEHAVIOR__\\
            if (distance < SourceCode.soldierVisionDistance && distance > 2)
            {

                //Animation
                animator.SetBool("SeePlayer", true);

                transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.soldierSpeed * Time.deltaTime);
            }

            //Timer && distance = Kill that mf
            if ((SourceCode.timeBtwAttacks <= 0) && (distance <= SourceCode.soldierVisionDistance))
            {
                animator.SetBool("Attack", true);
                //Fazer ser child
                Instantiate(SoldierAttack, negativeSpawAttack, Quaternion.identity);
                Instantiate(SoldierAttack, positiveSpawAttack, Quaternion.identity);
                SourceCode.timeBtwAttacks = SourceCode.startTimeBtwAttacks;
            }
            else
            {
                animator.SetBool("Attack", false);
                SourceCode.timeBtwAttacks -= Time.deltaTime;
            }

            ////////////__FlipX__\\\\\\\\\\\\
            /*if ((Vector2.MoveTowards.x > 0) && (spriteRender.flipX))
            {
                spriteRender.flipX = false;
            }
            else if ((horizontal < 0) && (!spriteRender.flipX))
            {
                spriteRender.flipX = true;
            }
            */

        }


        //Reset of the timer
        if (soldierLife <= 0)
        {
            animator.SetFloat("Life_Soldier", soldierLife);
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
