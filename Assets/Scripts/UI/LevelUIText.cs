using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIText : MonoBehaviour
{
    //LIFE
    public Text levelText;

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level " + SourceCode.playerLevel.ToString();
    }
}
