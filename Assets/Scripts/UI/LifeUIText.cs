using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUIText : MonoBehaviour
{
    //LIFE
    public Text lifeText;

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeText.text = SourceCode.lifePoints.ToString();
    }
}
