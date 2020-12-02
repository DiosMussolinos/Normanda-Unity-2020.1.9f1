using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDestroy : MonoBehaviour
{
    public float attackDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, attackDestroy);
    }
}