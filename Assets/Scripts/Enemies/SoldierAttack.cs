using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour
{
    public float SoldierAttackLife;

    void Start()
    {
        Destroy(gameObject, SoldierAttackLife);
    }

}
