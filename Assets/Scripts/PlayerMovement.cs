using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    //private GameObject spriteRender;
    private Animator animator;

    public float WalkSpeed = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Calling stuff
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //__movimento X & Y__\\
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * WalkSpeed, vertical * WalkSpeed);


        //__Animations__\\
        //__MOVEMENT X__\\
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
    }
}
