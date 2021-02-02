using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelSystem : MonoBehaviour
{
    //Backend stuff
    public string BaseAPI = "http://localhost:3909";


    void Update() 
    {
        LevelUp();   
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
            //Send to database
            string jsonstring = JsonUtility.ToJson(new PlayerNewLevel(SourceCode.playerLevel, SourceCode.userID));
            StartCoroutine(UpdateLevel(BaseAPI + "/updateLevel", jsonstring));

            //Restart of value 
            SourceCode.playerExp = SourceCode.playerExp - SourceCode.playerExpToNextLevel;
            //Restart Backend
            string jsonstringexp = JsonUtility.ToJson(new PlayerNewExp(SourceCode.playerExp, SourceCode.userID));
            StartCoroutine(UpdateExp(BaseAPI + "/updateExp", jsonstringexp));
            
            //Bonus Life
            SourceCode.lifePoints += 5;

            //New MAX LIFE
            SourceCode.maxLifePoints += 5;

            //New CD For the Strong Attack
            SourceCode.strongAttackCD = SourceCode.strongAttackCD - 0.1f;
            //Bonus Gold  
            SourceCode.playerGold = SourceCode.playerGold + 10;

            ////////////////////////__ARCHER__\\\\\\\\\\\\\\\\\\\\\\\\
            SourceCode.projectileDamage += 2;
            SourceCode.archerGold += 3;
            //Less CD in shots
            SourceCode.timeBtwShots = SourceCode.timeBtwShots - 0.05f;

            ////////////////////////__SOLDIER__\\\\\\\\\\\\\\\\\\\\\\\\
            SourceCode.soldierDamage += 2;
            SourceCode.soldierExp += 3;

            ////////////////////////__Final Boss__\\\\\\\\\\\\\\\\\\\\\\\\
            SourceCode.finalBossLife += 10;
            SourceCode.finalBossEXP += 5;
            SourceCode.finalBossGold += 7;
        }
    }

    IEnumerator UpdateLevel(string url, string json)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonbyte = new System.Text.UTF8Encoding().GetBytes(json);

        webRequest.uploadHandler = new UploadHandlerRaw(jsonbyte);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();


        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            SourceCode.playerLevel = int.Parse(webRequest.downloadHandler.text);
        }
    }

    IEnumerator UpdateExp(string url, string json)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonbyte = new System.Text.UTF8Encoding().GetBytes(json);

        webRequest.uploadHandler = new UploadHandlerRaw(jsonbyte);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();


        if (webRequest.isNetworkError)
        {
            Debug.Log(webRequest.error);
        }
        else
        {
            SourceCode.playerGold = int.Parse(webRequest.downloadHandler.text);
        }
    }

}
