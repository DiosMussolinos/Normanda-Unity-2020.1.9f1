using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    void Update() 
    {

        LevelUp();
        Debug.Log(SourceCode.lifePoints);
    }

    private void LevelUp()
    {

        //Foruma to develop the levels\\
        if (SourceCode.playerLevel == 1)
        {
            SourceCode.playerExpToNextLevel = 10 * SourceCode.playerLevel;
        }
        else
        {
            SourceCode.playerExpToNextLevel = 10 + (3 * SourceCode.playerLevel) + (3 * (SourceCode.playerLevel - 1));
        }


        //__LEVEL UP!!!__\\
        if (SourceCode.playerExp >= SourceCode.playerExpToNextLevel)
        {

            ////////////////////////__PLAYER__\\\\\\\\\\\\\\\\\\\\\\\\
            //Level + 1
            SourceCode.playerLevel = SourceCode.playerLevel + 1;
            //Restart of value 
            SourceCode.playerExp = SourceCode.playerExp - SourceCode.playerExpToNextLevel;
            //New CD For the Strong Attack
            SourceCode.strongAttackCD = SourceCode.strongAttackCD - 0.1f;
            //Bonus Gold  
            SourceCode.playerGold = SourceCode.playerGold + 10;

            ////////////////////////__ARCHER__\\\\\\\\\\\\\\\\\\\\\\\\
            //Bigger Life
            SourceCode.archerLife = SourceCode.archerLife + 2;
            //Less CD in shots
            SourceCode.timeBtwShots = SourceCode.timeBtwShots - 0.05f;


            ////////////////////////__SOLDIER__\\\\\\\\\\\\\\\\\\\\\\\\
            //Bigger Life
            SourceCode.soldierLife = SourceCode.soldierLife + 2;
        }
    }
}
