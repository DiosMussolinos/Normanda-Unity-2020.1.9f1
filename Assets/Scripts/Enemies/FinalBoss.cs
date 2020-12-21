using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public int finalBossLife = 40;
    public int maxFinalBossLife = 40;

    public float interestedStartTimer = 3;
    public float interestedTime;
    
    //Calling stuff
    public GameObject topDownAttacks;
    public GameObject sideAttacks;
    public Transform player;
    public Transform startPosition;
    public GameObject portal;


    private bool interest = true;



    // Awake is called before Start
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPosition = GameObject.FindWithTag("PosiçãoInicial").transform;
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
        if ((distance < 5) && (interest = true) && (interestedTime > 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.finalBossSpeed * Time.deltaTime);
        }
        else
        {
            interest = false;
        }
        
        //Desativa o interesse do player
        //Não permite ele a recuperar interesse até o timer ser o TOTAL
        if ((interest == false) && (interestedTime <= 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition.position, SourceCode.finalBossSpeed * Time.deltaTime);
        }

        if(transform.position == startPosition.position)
        {
            interest = true;
            finalBossLife = maxFinalBossLife;
            interestedTime = interestedStartTimer;
        }
        //__BEHAVIOR__\\

        //Timer && distance = Kill that mf
        if ((SourceCode.finalBossTimeBtwAttacks <= 0) && (distance < 3f))
        {
            
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
            //Ser a putinha do player e dar suas recompensas
            SourceCode.playerExp = SourceCode.playerExp + SourceCode.finalBossEXP;
            SourceCode.playerGold = SourceCode.playerGold + SourceCode.finalBossGold;

            //Ativar Portal para a cidade
            portal.gameObject.SetActive(true);

            //Morte ao capitalismo
            Destroy(gameObject);
        }
        InterestedTime();
    }

    private void InterestedTime()
    {
        if(interest == false)
        {
            interestedTime -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            //Recieve DMG BasicAttack
            finalBossLife = finalBossLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            //Recieve DMG Strong
            finalBossLife = finalBossLife - SourceCode.strongAttackDMG;
        }

        //Colision with the bullet
        if (collision.gameObject.CompareTag("Shot"))
        {
            //Recieve DMG Strong
            finalBossLife = finalBossLife - SourceCode.projectileDamage;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Desativa o interesse do player
        //Não permite ele a recuperar interesse até o timer ser o TOTAL
        if (collision.gameObject.CompareTag("TocaFinalBoss"))
        {
            interest = false;
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
