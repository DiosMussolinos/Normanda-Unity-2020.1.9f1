using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticNPC : MonoBehaviour
{
    public GameObject dialogBox;
    public Image pressToTalk;
    public Text dialogText;
    public string[] dialog;
    public bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
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
