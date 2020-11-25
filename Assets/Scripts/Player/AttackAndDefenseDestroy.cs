using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAndDefenseDestroy : MonoBehaviour
{
    public float attackAnDefenseDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, attackAnDefenseDestroy);
    }
}
