using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    ////////////__Private__\\\\\\\\\\\\
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;
    
    ////////////__Public__\\\\\\\\\\\\
    public GameObject BasicAttackPrefab;
    public GameObject StrongAttackPrefab;
    public bool blockInstantiate = false;
    //Shield Defense Information\\
    public GameObject ShieldPrefab;

    //Public Hit Information\\
    //public float hitCd;
    //public float hitTimer = 0.3f; 

    //Awake is called before the Start
    void Awake()
    {
        ////////////__Calling stuff__\\\\\\\\\\\\
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ////////////__movimento X & Y__\\\\\\\\\\\\
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ////////////__Attacks && Defenses__\\\\\\\\\\\\
        
        float basicAttack = Input.GetAxis("Fire1");
        float strongAttack = Input.GetAxis("Fire2");
        float block = Input.GetAxis("Fire3");

        // Life > 0 then MOVE, YOU ARE ON MY WAY
        if (SourceCode.lifePoints > 0)
        {
            rb.velocity = new Vector2(horizontal * SourceCode.walkSpeed, vertical * SourceCode.walkSpeed);

            ////////////__FlipX__\\\\\\\\\\\\
            if ((horizontal > 0) && (spriteRender.flipX))
            {
                spriteRender.flipX = false;
            }
            else if ((horizontal < 0) && (!spriteRender.flipX))
            {
                spriteRender.flipX = true;
            }
        } 
        else 
        {
            rb.velocity = new Vector2(0, 0);
        }

        ////////////__ANIMATIONS__\\\\\\\\\\\\
        //__MOVEMENT X & Y__\\
        if (horizontal != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else if (vertical != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.y));
        }
        else
        {
            animator.SetFloat("Speed", -1);
        }


        //__BASIC ATTACK__\\
        if ((basicAttack != 0) && (SourceCode.basicAttackTimer <= 0))
        {
            //Animação
            animator.SetBool("BasicAttack", true);

            //Create Object\\
            //Right BasicAttack
            GameObject BasicAttackRight = Instantiate(BasicAttackPrefab, new Vector3(transform.position.x, transform.position.y + 1), Quaternion.identity);
            //Left BasicAttack
            GameObject BasicAttackLeft = Instantiate(BasicAttackPrefab, new Vector3(transform.position.x - 2.4f, transform.position.y + 1), Quaternion.identity);
            
            //Reset Timer
            SourceCode.basicAttackTimer = SourceCode.basicAttackCD;
        } else if(SourceCode.basicAttackTimer > 0)
        {
            animator.SetBool("BasicAttack", false);
        }


        //__STRONG ATTACK__\\
        if ((strongAttack != 0) && (SourceCode.strongAttackTimer <= 0))
        {
            //Animação
            animator.SetBool("StrongAttack", true);

            //Create Object\\
            //Right StrongAttack
            GameObject StrongAttackRight = Instantiate(StrongAttackPrefab, new Vector3(transform.position.x, transform.position.y + 1), Quaternion.identity);
            //Left StrongAttack
            GameObject StrongAttackLeft = Instantiate(StrongAttackPrefab, new Vector3(transform.position.x - 2.78f, transform.position.y + 1), Quaternion.identity);

            //Reset Timer
            SourceCode.strongAttackTimer = SourceCode.strongAttackCD;

        } else if (SourceCode.strongAttackTimer > 0)
        {
            animator.SetBool("StrongAttack", false);
        }


        //__BLOCK__\\
        if ((block != 0) && (!blockInstantiate))
        {
            //Animação
            animator.SetBool("Shield", true);

            //Create Object\\
            //Right Shield
            GameObject SheildDefenseRight = Instantiate(ShieldPrefab, new Vector3(transform.position.x, transform.position.y + 1), Quaternion.identity);
            //Left Shield
            GameObject SheildDefenseLeft = Instantiate(ShieldPrefab, new Vector3(transform.position.x - 1.6f, transform.position.y + 1), Quaternion.identity);

            //Reset Timer
            //SourceCode.shieldDefenseTimer = SourceCode.shieldCD;
            //Vel = 0;
            rb.velocity = new Vector2(0, 0);


            blockInstantiate = true;
        }

        if  ((block == 0) && (blockInstantiate = true))
        {
            animator.SetBool("Shield", false);
            blockInstantiate = false;
        }


        //__DEATH__\\
        if (SourceCode.lifePoints <= 0) 
        {
            animator.SetBool("Death", true);
        }

        
        Timer();
    }
    //__END UPDATE__\\

    private void Timer() 
    {
        //__ANIMATION TIMER__\\
        //Basic Attack
        if (SourceCode.basicAttackTimer >= 0)
        {
            SourceCode.basicAttackTimer -= Time.deltaTime;
        }

        //Strong Attack
        if (SourceCode.strongAttackTimer >= 0)
        {
            SourceCode.strongAttackTimer -= Time.deltaTime;
        }

        //Shield
        //if (SourceCode.shieldDefenseTimer >= 0)
        //{
        //    SourceCode.shieldDefenseTimer -= Time.deltaTime;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //__Collision With Archer Shot__\\
        if (collision.gameObject.CompareTag("Shot"))
        {
            SourceCode.lifePoints = SourceCode.lifePoints - SourceCode.projectileDamage;         
        }

        //__Collision With Soldier__\\
        if (collision.gameObject.CompareTag("Soldier"))
        {
            SourceCode.lifePoints = SourceCode.lifePoints - SourceCode.soldierCollisionDamage;
        }

        //__Collision With Soldier Attack__\\
        if (collision.gameObject.CompareTag("SoldierAttack"))
        {
            SourceCode.lifePoints = SourceCode.lifePoints - SourceCode.soldierDamage;
        }

        //__Collision With Final Boss__\\
        if (collision.gameObject.CompareTag("FinalBoss"))
        {
            SourceCode.lifePoints = SourceCode.lifePoints - SourceCode.finalBossTouchDamage;
        }

        //__Collision With Final Boss Attack__\\
        if (collision.gameObject.CompareTag("FinalBossAttack"))
        {
            SourceCode.lifePoints = SourceCode.lifePoints - SourceCode.finalBossAttackDamage;
        }

    }
    
    /*
    ⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⣠⣤⣶⣶
    ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⢰⣿⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣀⣀⣾⣿⣿⣿⣿
    ⣿⣿⣿⣿⣿⡏⠉⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿
    ⣿⣿⣿⣿⣿⣿⠀⠀⠀⠈⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠁⠀⣿
    ⣿⣿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠙⠿⠿⠿⠻⠿⠿⠟⠿⠛⠉⠀⠀⠀⠀⠀⣸⣿
    ⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣴⣿⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⢰⣹⡆⠀⠀⠀⠀⠀⠀⣭⣷⠀⠀⠀⠸⣿⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠈⠉⠀⠀⠤⠄⠀⠀⠀⠉⠁⠀⠀⠀⠀⢿⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⢾⣿⣷⠀⠀⠀⠀⡠⠤⢄⠀⠀⠀⠠⣿⣿⣷⠀⢸⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⡀⠉⠀⠀⠀⠀⠀⢄⠀⢀⠀⠀⠀⠀⠉⠉⠁⠀⠀⣿⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿
    ⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿
    When your spaghetthi code works
        & The professor likes
    */

}
