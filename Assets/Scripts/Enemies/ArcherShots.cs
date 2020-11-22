using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShots : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

    // Awake is called before Start
    void Awake() {

        player = GameObject.FindWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }

    }

}
