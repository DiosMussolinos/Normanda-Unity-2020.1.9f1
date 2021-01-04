using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartD1 : MonoBehaviour
{

    private Transform player;

    private Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        pos = gameObject.GetComponent<Transform>();

        pos.transform = player.transform;
        pos.transform = player.transform;
    }
}
