using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDefenseDestroy : MonoBehaviour
{

    public float shieldLife;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, shieldLife);   
    }
}
