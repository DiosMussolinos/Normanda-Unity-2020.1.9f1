using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class Server : MonoBehaviour
{
    public InputField userName;
    public InputField userPassword;

    public GameObject errorImage;
    public Text errorMessage;

    public Button loginButton;

    public string BaseAPI = "http://localhost:3909";

    public void Start() 
    {
        errorImage.SetActive(false);
    }

    public void OnLoginClick()
    {
        string user_name = userName.ToString();
        string user_pass = userPassword.ToString();

        loginButton.interactable = false;
        string jsonstring = JsonUtility.ToJson(new NewPlayerInfo(user_name, user_pass));
        StartCoroutine(PostRequestLogin(BaseAPI + "/login", jsonstring));
    }

    IEnumerator PostRequestLogin(string url, string json)
    {
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");
        byte[] jsonbyte = new System.Text.UTF8Encoding().GetBytes(json);

        webRequest.uploadHandler = new UploadHandlerRaw(jsonbyte);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError) 
        {
            //Debug.Log(userName.text);
            //Debug.Log(userPassword.text);
            
            Debug.Log(webRequest.error);
        }
        else
        {
            //Debug.Log(userName.text);
            //Debug.Log(userPassword.text);

            Debug.Log(webRequest.downloadHandler.text);
        }



    }

}
