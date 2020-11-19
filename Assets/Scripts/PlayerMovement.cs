using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //__Private__\\
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;
   
    //__Public__\\
    public float walkSpeed = 6f;
    //Player Information\\
    public int lifePoints = 100;
    public int level = 1;
    public int exp = 0;



    //Awake is called before the first frame
    void Awake()
    {
        //Calling stuff
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
        //__movimento X & Y__\\
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float basicAttack = Input.GetAxis("Fire1");
        float strongAttack = Input.GetAxis("Fire2");
        //float block = Input.GetAxis("Fire1");

        rb.velocity = new Vector2(horizontal * walkSpeed, vertical * walkSpeed);

        //__FlipX__\\
        if ((horizontal > 0) && (spriteRender.flipX))
        {
            spriteRender.flipX = false;
        }
        else if ((horizontal < 0) && (!spriteRender.flipX))
        {
            spriteRender.flipX = true;
        }

        //__Animations__\\
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
        }
        else
        {
            animator.SetBool("BasicAttack", false);
        }

        if (strongAttack != 0)
        {
            animator.SetBool("StrongAttack", true);
        }
        else
        {
            animator.SetBool("StrongAttack", false);
        }

    }
}
