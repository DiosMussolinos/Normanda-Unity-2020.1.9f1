using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStrongDestroy : MonoBehaviour
{

    public float strongAttackLife;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, strongAttackLife);
    }
}
