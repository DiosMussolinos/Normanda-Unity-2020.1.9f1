using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{   
    //Calling stuff
    public GameObject SoldierAttack;
    public Transform player;
    private float soldierScale;
    private Rigidbody2D rb;

    // Awake is called before Start
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        soldierScale = (transform.localScale.x / 2) + 1f;
       
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

        //__BEHAVIOR__\\
        if (distance < SourceCode.soldierVisionDistance && distance > 2) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.soldierSpeed * Time.deltaTime);
        }



        //Timer && distance = Kill that mf
        if ((SourceCode.timeBtwAttacks <= 0) && (distance <= SourceCode.soldierVisionDistance))
        {
            //Fazer ser child
            Instantiate(SoldierAttack, negativeSpawAttack, Quaternion.identity);
            Instantiate(SoldierAttack, positiveSpawAttack, Quaternion.identity);
            SourceCode.timeBtwAttacks = SourceCode.startTimeBtwAttacks;
        }
        else
        {
            SourceCode.timeBtwAttacks -= Time.deltaTime;
        }
        
        //Reset of the timer
        if (SourceCode.soldierLife <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            SourceCode.soldierLife = SourceCode.soldierLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            SourceCode.soldierLife = SourceCode.soldierLife - SourceCode.strongAttackDMG;
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
