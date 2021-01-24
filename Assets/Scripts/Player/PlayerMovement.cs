using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    ////////////__Private__\\\\\\\\\\\\
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;
    
    ////////////__Public__\\\\\\\\\\\\
    public GameObject BasicAttackPrefab;
    public GameObject StrongAttackPrefab;
    public GameObject ShieldPrefab;

    //Time to Hit
    public float basicTimeToHit = 0.7f;
    public float strongTimeToHit = 0.4f;
    public float shieldTimeToHit = 0.5f;


    //Awake is called before the Start
    void Awake()
    {
        ////////////__Calling stuff__\\\\\\\\\\\\
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();

        DontDestroyOnLoad(this.gameObject);

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


        ////////////////////////__CHEAT CODES\\\\\\\\\\\\\\\\\\\\\\\\

        if (Input.GetKeyDown(KeyCode.L))
        {
            SourceCode.lifePoints = SourceCode.maxLifePoints;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SourceCode.playerGold += 100;
        }
        ////////////////////////__CHEAT CODES\\\\\\\\\\\\\\\\\\\\\\\\


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

        //__MOVEMENT X & Y__\\
        //__BASIC ATTACK__\\
        if ((basicAttack != 0) && (SourceCode.basicAttackTimer <= 0))
        {
            //Animação
            animator.SetBool("BasicAttack", true);
            

            ////Create Object & Timer To create\\\\
           
                if (spriteRender.flipX) {
                    GameObject BasicAttackRight = Instantiate(BasicAttackPrefab, new Vector3(transform.position.x-1.5f, transform.position.y + 1), Quaternion.identity);
                }
                if (!spriteRender.flipX)
                {
                    GameObject BasicAttackLeft = Instantiate(BasicAttackPrefab, new Vector3(transform.position.x +1.3f, transform.position.y + 1), Quaternion.identity);
                }
            

            //Reset Timer
            SourceCode.basicAttackTimer = SourceCode.basicAttackCD;

        } else if(SourceCode.basicAttackTimer > 0)
        {
            //Return To Idle or others
            animator.SetBool("BasicAttack", false);
    
        }


        //__STRONG ATTACK__\\
        if ((strongAttack != 0) && (SourceCode.strongAttackTimer <= 0))
        {
            //Animação
            animator.SetBool("StrongAttack", true);
            

            ////Create Object & Timer To create\\\\
           
                if (spriteRender.flipX)
                {
                    GameObject StrongAttackRight = Instantiate(StrongAttackPrefab, new Vector3(transform.position.x - 1.5f, transform.position.y + 1), Quaternion.identity);
                }
                if (!spriteRender.flipX)
                {
                    GameObject StrongAttackLeft = Instantiate(StrongAttackPrefab, new Vector3(transform.position.x + 1.3f, transform.position.y + 1), Quaternion.identity);
                }
            
            //Reset Timer
            SourceCode.strongAttackTimer = SourceCode.strongAttackCD;

        } else if (SourceCode.strongAttackTimer > 0)
        {
            //Return To Idle or others
            animator.SetBool("StrongAttack", false);
            strongTimeToHit = 0.4f;
        }

        //__BLOCK__\\
        if ((block != 0) && (SourceCode.blockInstantiate != true))
        {
            //Animação
            animator.SetBool("Shield", true);

            //Parar
            //TODO: TENTAR FAZER ESSA PORRA FUNCIONAR

            ////Create Object & Timer To create\\\\
            if (spriteRender.flipX)
            {
                GameObject SheildDefenseRight = Instantiate(ShieldPrefab, new Vector3(transform.position.x - 0.83f, transform.position.y + 1), Quaternion.identity);
            }
            if (!spriteRender.flipX)
            {
                GameObject SheildDefenseLeft = Instantiate(ShieldPrefab, new Vector3(transform.position.x + 0.75f, transform.position.y + 1), Quaternion.identity);
            }
            //if(blockInstantiate = true) { DONT INTANTIATE AGAIN }
            SourceCode.blockInstantiate = true;
        }

        if  ((block == 0) && (SourceCode.blockInstantiate = true))
        {
            //Destroy shield prefab instanciate
            animator.SetBool("Shield", false);
            SourceCode.blockInstantiate = false;
        }


        //__DEATH__\\
        if (SourceCode.lifePoints <= 0) 
        {
            //Ridigbody OFF
            rb.bodyType = RigidbodyType2D.Kinematic;
            //ANIMAÇÃO
            animator.SetBool("Death", true);
        } else 
        {
            //Rididbody ON
            rb.bodyType = RigidbodyType2D.Dynamic;
            //ANIMAÇÃO
            animator.SetBool("Death", false);
        }

        if(SourceCode.lifePoints > SourceCode.maxLifePoints) 
        {
            SourceCode.lifePoints = SourceCode.maxLifePoints;
        }

        if (SourceCode.lifePoints < 0)
        {
            SourceCode.lifePoints = 0;
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

        if(basicTimeToHit >= 0) 
        {
            basicTimeToHit -= Time.deltaTime;
        }

        if (strongTimeToHit >= 0)
        {
            strongTimeToHit -= Time.deltaTime;
        }

        if (shieldTimeToHit >= 0)
        {
            shieldTimeToHit -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //__Collision With Archer Shot__\\
        if (collision.gameObject.CompareTag("Shot"))
        {
            SourceCode.lifePoints -= SourceCode.projectileDamage;
        }

        //__Collision With Soldier__\\
        if (collision.gameObject.CompareTag("Soldier"))
        {
            SourceCode.lifePoints -= SourceCode.soldierCollisionDamage;
        }

        //__Collision With Soldier Attack__\\
        if (collision.gameObject.CompareTag("SoldierAttack"))
        {
            if (SourceCode.blockInstantiate == true)
            {
                SourceCode.lifePoints = (int)(SourceCode.lifePoints - (SourceCode.soldierDamage - SourceCode.percentageDefense/10));
            }
            else
            {
                SourceCode.lifePoints -= SourceCode.soldierDamage;
            }
        }

        //__Collision With Final Boss__\\
        if (collision.gameObject.CompareTag("FinalBoss"))
        {
            SourceCode.lifePoints -= SourceCode.finalBossTouchDamage;
        }

        //__Collision With Final Boss Attack__\\
        if (collision.gameObject.CompareTag("FinalBossAttack"))
        {
            if (SourceCode.blockInstantiate == true)
            {
                SourceCode.lifePoints = (int)(SourceCode.lifePoints - (SourceCode.finalBossAttackDamage - SourceCode.percentageDefense / 10));
            }
            else
            {
                SourceCode.lifePoints -= SourceCode.finalBossAttackDamage;
            }
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
