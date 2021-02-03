using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Archer : MonoBehaviour
{

    public int archerLife;

    //Calling stuff
    public GameObject projectile;
    public Transform player;
    private SpriteRenderer spriteRender;
    private Animator animator;


    public float timeBtwAttacks;
    public float startTimeBtwAttacks;

    //Backend stuff
    public string BaseAPI = "http://localhost:3909";

    // Awake is called before Start
    void Awake()
    {
        //Find Player Position
        player = GameObject.FindWithTag("Player").transform;
        
        //Find Component
        spriteRender = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance from Enemy and Player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //Distance From The player in the X to Flip    
        float distanceXFromPlayer = transform.position.x - player.transform.position.x;


        ////////////////////////__BEHAVIOR__\\\\\\\\\\\\\\\\\\\\\\\\
        if (distance > SourceCode.archerStoppingDistance)
        {
            transform.position = this.transform.position;

            animator.SetBool("Walk", false);
        
        }
        if (distance < SourceCode.archerRetreaDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -SourceCode.archerSpeed * Time.deltaTime);
            
            animator.SetBool("Walk", true);
        }
        ////////////////////////__BEHAVIOR__\\\\\\\\\\\\\\\\\\\\\\\\


        if (distanceXFromPlayer > 0)
        {
            //Turn around
            spriteRender.flipX = true;

            if ((timeBtwAttacks <= 0) && (distance <= SourceCode.archerVisionDistance))
            {
                //Create Shot
                Instantiate(projectile, new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z), Quaternion.identity);
                //RestartTimer
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                //RestartTheCountDown
                timeBtwAttacks -= Time.deltaTime;
            }
        }

        if (distanceXFromPlayer < 0)
        {
            //Turn around
            spriteRender.flipX = false;

            if ((timeBtwAttacks <= 0) && (distance <= SourceCode.archerVisionDistance))
            {
                //Create Shot
                Instantiate(projectile, new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z), Quaternion.identity);
                //RestartTimer
                timeBtwAttacks = startTimeBtwAttacks;
            }
            else
            {
                //RestartTheCountDown
                timeBtwAttacks -= Time.deltaTime;
            }
        }

        //Death
        if (archerLife <= 0)
        {
            //Giving EXP
            SourceCode.playerExp += SourceCode.archerExp;
            //Exp to backend
            string jsonstringexp = JsonUtility.ToJson(new PlayerNewExp(SourceCode.playerExp, SourceCode.userID));
            StartCoroutine(UpdateGold(BaseAPI + "/updateExp", jsonstringexp));

            //Giving Gold
            SourceCode.playerGold += SourceCode.archerGold;
            //Gold to backend
            string jsonstring = JsonUtility.ToJson(new PlayerNewGold(SourceCode.playerGold, SourceCode.userID));
            StartCoroutine(UpdateGold(BaseAPI + "/updateGold", jsonstring));

            if (SourceCode.challengeActive == true) 
            {
                SourceCode.EnemiesKilleForChallenge += 1;
            }
            else
            {
                SourceCode.EnemiesKilleForChallenge = 0;
            }

            //Suicide
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Colision basic attack
        if (collision.gameObject.CompareTag("BasicAttack"))
        {
            //Recieve DMG BasicAttack
            archerLife = archerLife - SourceCode.basicAttackDMG;
        }

        //Colision Strong attack
        if (collision.gameObject.CompareTag("StrongAttack"))
        {
            //Recieve DMG Strong
            archerLife = archerLife - SourceCode.strongAttackDMG;
        }
    }

    IEnumerator UpdateGold(string url, string json)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonbyte = new System.Text.UTF8Encoding().GetBytes(json);

        webRequest.uploadHandler = new UploadHandlerRaw(jsonbyte);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();


        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            SourceCode.playerGold = int.Parse(webRequest.downloadHandler.text);
        }
    }

    IEnumerator UpdateExp(string url, string json)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonbyte = new System.Text.UTF8Encoding().GetBytes(json);

        webRequest.uploadHandler = new UploadHandlerRaw(jsonbyte);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();


        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            SourceCode.playerGold = int.Parse(webRequest.downloadHandler.text);
        }
    }

}
