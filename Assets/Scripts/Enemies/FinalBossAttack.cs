using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossAttack : MonoBehaviour
{
    public float bossAttackLife;

    void Start()
    {
        Destroy(gameObject, bossAttackLife);
    }

}
