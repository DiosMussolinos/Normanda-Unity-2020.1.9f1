using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    void Update() 
    {

        LevelUp();

    }

    private void LevelUp()
    {
        if (SourceCode.playerLevel == 1)
        {
            SourceCode.playerExpToNextLevel = 10 * SourceCode.playerLevel;
        }
        else
        {
            SourceCode.playerExpToNextLevel = 10 + (3 * SourceCode.playerLevel) + (3 * (SourceCode.playerLevel - 1));
        }

        if (SourceCode.playerExp >= SourceCode.playerExpToNextLevel)
        {
            SourceCode.playerLevel = SourceCode.playerLevel + 1;
            SourceCode.playerExp = SourceCode.playerExp - SourceCode.playerExpToNextLevel;
        }
    }
}
