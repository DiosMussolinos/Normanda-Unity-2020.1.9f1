using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIText1 : MonoBehaviour
{
    //LIFE
    public Text levelText;

    // Update is called once per frame
    void FixedUpdate()
    {
        levelText.text = "Level " + SourceCode.playerLevel.ToString();
    }
}
