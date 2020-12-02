using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDestroy : MonoBehaviour
{
    void Update()
    {
        if (SourceCode.blockInstantiate == false)
        {

            Destroy(gameObject);

        }
    }
}
