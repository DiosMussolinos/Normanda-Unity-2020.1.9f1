using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float healthSize = (SourceCode.lifePoints / 100);
        transform.localScale = new Vector3(healthSize, 1, 1);
    }
}
