using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicNPC : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialog;
    public bool playerInRange = false;

    public float moveSpeed;
    public Vector3[] npcPoints;
    public int pointsIndex;
    public GameObject controlE;

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
                pointsIndex++;
                
            }

            if (pointsIndex == (npcPoints.Length))
            {
                pointsIndex = 0;
            }
        }

        if ((Input.GetKeyDown(KeyCode.E)) && (playerInRange == true))
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {

                dialogBox.SetActive(true);
                dialogText.text = dialog[Random.Range(0, dialog.Length)];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {

            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
