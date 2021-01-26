using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DynamicNPC : MonoBehaviour
{
    private DynamicNPC exist;

    public GameObject dialogBox;
    public Text dialogText;
    public Image pressToTalk;
    public string[] dialog;
    public bool playerInRange = false;

    public float moveSpeed;
    public Vector3[] npcPoints;
    public int pointsIndex;
    public GameObject controlE;
    public Transform pressToTalkPos;

    //Scene related
    private Scene scene;
    private string sceneName;
    private SpriteRenderer spriteRender;

    //PickStuff
    private Rigidbody2D rb;

    void Awake() 
    {
        if (exist == null)
        {
            exist = this;
        }

        if (exist != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pressToTalk.enabled = false;

        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        if (sceneName != "N1")
        {
            gameObject.SetActive(false);
        }

        if (dialogText == null)
        {
            Destroy(gameObject);
        }

        if (playerInRange == false)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, npcPoints[pointsIndex], moveSpeed * Time.deltaTime);

            if (transform.position == npcPoints[pointsIndex])
            {
                //Next point of the array of Locations
                pointsIndex++;
            }

            if (pointsIndex == (npcPoints.Length))
            {
                //Going Back to the start point
                pointsIndex = 0;
            }
        }

        if ((Input.GetKeyDown(KeyCode.E)) && (playerInRange == true))
        {
            if (dialogBox.activeInHierarchy)
            {
                //Not worthy for a good joke
                dialogBox.SetActive(false);
            }
            else
            {
                //Have a free sample of a joke
                dialogBox.SetActive(true);
                dialogText.text = dialog[Random.Range(0, dialog.Length)];
            }
        }

        if (pointsIndex > 0)
        {
            if (npcPoints[pointsIndex].x < npcPoints[pointsIndex - 1].x)
            {
                spriteRender.flipX = true;
            }
            else
            {
                spriteRender.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //Npc Stop
            playerInRange = true;
            //Press an be happy
            pressToTalk.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            //Npc walks
            playerInRange = false;
            //Joke off
            dialogBox.SetActive(false);
            //Off the happy moments
            pressToTalk.enabled = false;
        }
    }
}
