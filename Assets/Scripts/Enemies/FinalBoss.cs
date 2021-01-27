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
    //////////////\\\\\\\\\\\\\\
    private bool interest = true;

    //Animator & Sprite Renderer
    private Animator animator;
    private SpriteRenderer spriteRender;



    // Awake is called before Start
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPosition = GameObject.FindWithTag("PosiçãoInicial").transform;
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();

        portal.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from Enemy and Player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Distance From The player in the X to Flip    
        float distanceXFromPlayer = transform.position.x - player.transform.position.x;

        //__BEHAVIOR__\\
        if ((distance > 3) && (distance < 8) && (interest = true) && (interestedTime > 0))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, SourceCode.finalBossSpeed * Time.deltaTime);
        }
        else
        {
            interest = false;
        }
        
        //Flip X
        if(distanceXFromPlayer > 0)
        {
            spriteRender.flipX = false;
        }
        else
        {
            spriteRender.flipX = true;
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

            animator.SetInteger("Attack", 1);
            Invoke("Attacks", 0.3f);
            SourceCode.finalBossTimeBtwAttacks = SourceCode.finalBossStartTimeBtwAttacks;
        }
        else
        {
            animator.SetInteger("Attack", 0);
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

    private void Attacks()
    {
        //Position of The Attacks
        Vector3 attackTop = new Vector3(transform.position.x, transform.position.y + 2.6f, transform.position.z);
        Vector3 attackBottom = new Vector3(transform.position.x, transform.position.y - 2.6f, transform.position.z);
        Vector3 attackLeft = new Vector3(transform.position.x - 2.6f, transform.position.y, transform.position.z);
        Vector3 attackRight = new Vector3(transform.position.x + 2.6f, transform.position.y, transform.position.z);

        Instantiate(topDownAttacks, attackTop, Quaternion.identity);
        Instantiate(topDownAttacks, attackBottom, Quaternion.identity);
        Instantiate(sideAttacks, attackLeft, Quaternion.Euler(0,0,-90));
        Instantiate(sideAttacks, attackRight, Quaternion.Euler(0, 0, -90));
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
