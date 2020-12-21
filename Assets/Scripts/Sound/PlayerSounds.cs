using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody2D rb;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        audioSource.loop = true;
    }

    private void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            audioSource.UnPause();
        }

        else
        {
            audioSource.Pause();
        }
    }

}
