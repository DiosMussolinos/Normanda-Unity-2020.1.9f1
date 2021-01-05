using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class D2ToN2 : MonoBehaviour
{
    public Transform player;
    public GameObject teleport;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("N2");
            player.transform.position = new Vector2(teleport.transform.position.x, teleport.transform.position.y);

        }
    }

}
