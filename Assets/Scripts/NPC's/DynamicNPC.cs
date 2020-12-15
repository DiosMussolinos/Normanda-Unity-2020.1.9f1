using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicNPC : MonoBehaviour
{
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

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, npcPoints[pointsIndex], moveSpeed * Time.deltaTime);

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
