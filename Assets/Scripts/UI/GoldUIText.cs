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
    }
}

/*
    //EXP
    private int expUI = SourceCode.playerExp;
    public Text expText;

    //GOLD
    private int goldUI = SourceCode.playerGold;
    public Text goldText;

    // Update is called once per frame
    void Update()
    {
        lifeText.text = lifePointsUI.ToString();

        expText.text = expUI.ToString();

        goldText.text = goldUI.ToString();

    }*/