using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class register : MonoBehaviour
{
    public InputField userName;
    public InputField userPassword;
    public InputField confirmUserPassword;

    public GameObject errorImage;

    public Button registerButton;

    public string BaseAPI = "http://localhost:3909";

    public void OnLoginClick()
    {
        string user_name = userName.text;
        string user_pass = userPassword.text;
        string user_conf = confirmUserPassword.text;

        if (user_pass == user_conf)
        {
            errorImage.SetActive(false);
            string jsonstring = JsonUtility.ToJson(new NewPlayerInfo(user_name, user_pass));
            StartCoroutine(Register(BaseAPI + "/newPlayer", jsonstring));
        }
        else
        {
            errorImage.SetActive(true);
        }
    }
        
    IEnumerator Register(string url, string json)
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
            Debug.Log(webRequest.downloadHandler.text);

        }
    }

}


