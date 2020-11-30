using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    //Calling stuff
    public GameObject projectile;
    public Transform player;

    // Awake is called before Start
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
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

        //__BEHAVIOR__\\
        if (distance > SourceCode.archerStoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (distance < SourceCode.archerRetreaDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -SourceCode.archerSpeed * Time.deltaTime);
        }

        //Timer && distance = SHOOT THAT NUGGET
        if ((SourceCode.timeBtwShots <= 0) && (distance <= SourceCode.archerVisionDistance))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            SourceCode.timeBtwShots = SourceCode.startTimeBtwShots;
        }
        else
        {
            SourceCode.timeBtwShots -= Time.deltaTime;
        }

        //Reset of the timer
        if (SourceCode.archerLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            SourceCode.archerLife = SourceCode.archerLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            SourceCode.archerLife = SourceCode.archerLife - SourceCode.strongAttackDMG;
        }

    }
}
