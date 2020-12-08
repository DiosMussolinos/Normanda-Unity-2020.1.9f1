using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUIText : MonoBehaviour
{
    //GOLD
    public Text goldText;


    // Update is called once per frame
    void Update()
    {
        goldText.text = SourceCode.playerGold.ToString();
        //goldText.text = SourceCode.strongAttackCD.ToString();
    }
}