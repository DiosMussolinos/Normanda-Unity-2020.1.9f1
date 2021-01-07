using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaticNPC : MonoBehaviour
{
    private StaticNPC exist;

    private Scene scene;
    private string sceneName;

    public GameObject dialogBox;
    public Image pressToTalk;
    public Text dialogText;
    public string[] dialog;
    public bool playerInRange = false;

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

    void Start() 
    {
        pressToTalk.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogText == null)
        {
            Destroy(gameObject);
        }

        scene = SceneManager.GetActiveScene();

        sceneName = scene.name;

        if (sceneName != "N1")
        {
            gameObject.SetActive(false);
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
