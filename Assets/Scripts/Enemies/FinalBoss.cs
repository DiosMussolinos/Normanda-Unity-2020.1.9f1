using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public int finalBossLife = 40;

    //Calling stuff
    public GameObject topDownAttacks;
    public GameObject sideAttacks;
    public Transform player;
    public GameObject portal;

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

        //Position of The Attacks
        Vector3 attackTop = new Vector3(transform.position.x, transform.position.y + 2.6f, transform.position.z);
        Vector3 attackBottom = new Vector3(transform.position.x, transform.position.y - 2.6f, transform.position.z);
        Vector3 attackLeft = new Vector3(transform.position.x - 2.6f, transform.position.y, transform.position.z);
        Vector3 attackRight = new Vector3(transform.position.x + 2.6f, transform.position.y, transform.position.z);

        //__BEHAVIOR__\\
        if (distance < 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.finalBossSpeed * Time.deltaTime);
        }
        //__BEHAVIOR__\\

        //Timer && distance = Kill that mf
        if ((SourceCode.finalBossTimeBtwAttacks <= 0) && (distance < 2.5f))
        {
            //Fazer ser child
            Instantiate(topDownAttacks, attackTop, Quaternion.identity);
            Instantiate(topDownAttacks, attackBottom, Quaternion.identity);
            Instantiate(sideAttacks, attackLeft, Quaternion.Euler(0,0,-90));
            Instantiate(sideAttacks, attackRight, Quaternion.Euler(0, 0, -90));

            SourceCode.finalBossTimeBtwAttacks = SourceCode.finalBossStartTimeBtwAttacks;
        }
        else
        {
            SourceCode.finalBossTimeBtwAttacks -= Time.deltaTime;
        }

        //Reset of the timer
        if (finalBossLife <= 0)
        {
            SourceCode.playerExp = SourceCode.playerExp + SourceCode.finalBossEXP;
            SourceCode.playerGold = SourceCode.playerGold + SourceCode.finalBossGold;
            portal.gameObject.SetActive(true);
            Destroy(gameObject);
        }

        Debug.Log(finalBossLife);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            finalBossLife = finalBossLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            finalBossLife = finalBossLife - SourceCode.strongAttackDMG;
        }
    }

    /*
    ⠄⠄⠄⢀⣤⣾⣿⡟⠋⠄⠄⠄⣀⡿⠄⠊⠄⠄⠄⠄⠄⠄⢸⠇⠄⢀⠃⠙⣿⣿
    ⣤⠒⠛⠛⠛⠛⠛⠛⠉⠉⠉⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠸⠄⢀⠊⠄⠄⠈⢿
    ⣿⣠⠤⠴⠶⠒⠶⠶⠤⠤⣤⣀⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⠃⠄⠂⣀⣀⣀⡀⠄
    ⡏⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⠙⠂⠄⠄⠄⠄⠄⠄⢀⢎⠐⠛⠋⠉⠉⠉⠉⠛
    ⡇⠄⠄⠄⣀⡀⠄⠄⠄⢀⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠎⠁⠄⠄⠄⠄⠄⠄⠄⠄
    ⡧⠶⣿⣿⣿⣿⣿⣿⠲⠦⣭⡃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⡀⠄⠄⠄⠄⠄⠄
    ⡇⠄⣿⣿⣿⣿⣿⣿⡄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢰⣾⣿⣿⣿⡟⠛⠶⠄
    ⡇⠄⣿⣿⣿⣿⣿⣿⡇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣼⣿⣿⣿⣿⡇⠄⠄⢀
    ⡇⠄⢿⣿⣿⣿⣿⣷⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣿⣿⣿⣿⣿⡇⠄⠄⢊
    ⢠⠄⠈⠛⠛⠛⠛⠋⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢿⣿⣿⣿⡦⠁⠄⠄⣼
    ⢸⠄⠈⠉⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠉⠉⠄⠄⠄⠄⢰⣿
    ⢸⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠁⠉⠄⢸⣿
    ⠄⣆⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⣀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢸⣿
    ⠄⢿⣷⣶⣄⡀⠄⠄⠄⠄⠄⠄⠉⠉⠉⠉⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⣴⣿⣿
    ⠄⢸⣿⣿⣿⣿⣷⣦⣤⣀⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣀⣠⣤⣶⣿⣿⣿⣿⣿
    */
}
