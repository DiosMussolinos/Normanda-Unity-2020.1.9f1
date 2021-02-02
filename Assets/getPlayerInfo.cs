using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class getPlayerInfo : MonoBehaviour
{

    public string BaseAPI = "http://localhost:3909";

    // Awake is called before the Start
    void Awake() 
    {
        if (SourceCode.logged == true && SourceCode.userID != 0)
        {

            string jsonstring = JsonUtility.ToJson(new PlayerInfo(SourceCode.userID));
            //Life
            StartCoroutine(PostLife(BaseAPI + "/playerInfoLife", jsonstring));
            //EXP
            StartCoroutine(PostExp(BaseAPI + "/playerInfoExp", jsonstring));
            //Money
            StartCoroutine(PostGold(BaseAPI + "/playerInfoGold", jsonstring));
            //Level
            StartCoroutine(PostLevel(BaseAPI + "/playerInfoLevel", jsonstring));
        }
    }

    //Life
    IEnumerator PostLife(string url, string json)
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
            SourceCode.lifePoints = int.Parse(webRequest.downloadHandler.text);
        }
    }

    //EXP
    IEnumerator PostExp(string url, string json)
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
            SourceCode.playerExp = int.Parse(webRequest.downloadHandler.text);
        }
    }


    //Money
    IEnumerator PostGold(string url, string json)
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


    //Level
    IEnumerator PostLevel(string url, string json)
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
}
