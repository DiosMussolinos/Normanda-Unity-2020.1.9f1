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
    public float walkSpeed = 6f;
    //__Player Information\\\\\\\\\\\\
    public int lifePoints = 100;
    public int level = 1;
    public int exp = 0;

    //Basic Attack Information__\\
    public int basicAttackDMG = 0;
    public float basicAttackCD = 0f;

    //Strong Attack Information__\\
    public int strongAttackDMG = 0;
    public float strongAttackCD = 0f;


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
    void FixedUpdate()
    {
        ////////////__movimento X & Y__\\\\\\\\\\\\
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ////////////__Attacks && Defenses__\\\\\\\\\\\\
        float basicAttack = Input.GetAxis("Fire1");
        float strongAttack = Input.GetAxis("Fire2");
        float block = Input.GetAxis("Fire3");

        rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);

        ////////////__FlipX__\\\\\\\\\\\\
        if ((horizontal > 0) && (spriteRender.flipX))
        {
            spriteRender.flipX = false;
        }
        else if ((horizontal < 0) && (!spriteRender.flipX))
        {
            spriteRender.flipX = true;
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
        if (basicAttack != 0)
        {
            animator.SetBool("BasicAttack", true);
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            animator.SetBool("BasicAttack", false);
        }

        //__STRONG ATTACK__\\
        if (strongAttack != 0)
        {
            animator.SetBool("StrongAttack", true);
            rb.velocity = new Vector2(0,0);
        }
        else
        {
            animator.SetBool("StrongAttack", false);
        }

        //__BLOCK && SPEED 0,0__\\
        if (block != 0)
        {
            animator.SetBool("Block", true);
            rb.velocity = new Vector2(0,0);
        }
        else 
        {
            animator.SetBool("Block", false);
        }


        //__DEATH__\\
        animator.SetInteger("Health", lifePoints);
    
    }
}
