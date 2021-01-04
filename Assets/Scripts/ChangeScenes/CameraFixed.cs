using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixed : MonoBehaviour
{
    private Transform player;

    public float offsetX = 0f;
    public float offsetY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offsetX, player.position.y + 1 + offsetY, transform.position.z);
    }
}

