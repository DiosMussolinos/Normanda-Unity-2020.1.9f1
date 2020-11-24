using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    //Behavior
    public float speed;
    public float stoppingDistance;
    public float retreaDistance;
    public float visionDistance;

    //Control of shots
    public float timeBtwShots;
    public float startTimeBtwShots;

    //Details of Enemy
    public int archerLife;
    public int CollisionDamage;
    public int Damage;
    public int gold;
    public int experience;
    public int level;
    
    //Calling stuff
    public GameObject projectile;
    public Transform player;

    // Awake is called before Start
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
