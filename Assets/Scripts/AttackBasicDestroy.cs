using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBasicDestroy : MonoBehaviour
{

    public float basicAttackLife;
    //private float lifeTimer = 0f;

    // Update is called once per frame
    void Update()
    {
           Destroy(gameObject, basicAttackLife);
      
    }
}
