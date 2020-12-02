using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUIText : MonoBehaviour
{
    //EXP
    public Text expText;

    // Update is called once per frame
    void Update()
    {

        expText.text = SourceCode.playerExp.ToString();

    }
}
