using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShots : MonoBehaviour
{
    //Set speed
    public float speed;

    private float YOffSet = 0.5f;
    private Transform player;
    private Vector2 target;
    private Animator animator;

    // Awake is called before Start
    void Awake() {

        //Animator
        animator = GetComponent<Animator>();
        
        //Find the player
        player = GameObject.FindWithTag("Player").transform;
        
        //Initial position of the player 
        target = new Vector2(player.position.x, player.position.y + YOffSet);

    }

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        //movement of the Shot
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //Hits the initial position of the player, BOOM, GET REK
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collide with the player, BOOM, GET FUCKED
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        //Collide with the player, BOOM, GET ANAL
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

    }

}
