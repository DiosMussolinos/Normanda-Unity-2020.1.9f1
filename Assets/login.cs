using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class login : MonoBehaviour
{
    public InputField userName;
    public InputField userPassword;

    public GameObject errorImage;
    public Text errorMessage;

    public Button loginButton;

    public string BaseAPI = "http://localhost:3909";

    public MenuFunctions MenuFunctions;

    public void Start()
    {
        errorImage.SetActive(false);

        MenuFunctions.GetComponent<MenuFunctions>();
    }

    public void OnLoginClick()
    {
        string user_name = userName.text;
        string user_pass = userPassword.text;

        //loginButton.interactable = false;
        
        string jsonstring = JsonUtility.ToJson(new Login(user_name, user_pass));
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
            Debug.Log(webRequest.error);
            errorImage.SetActive(true);
        }
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
            int id = int.Parse(webRequest.downloadHandler.text);
            SourceCode.userID = id;
            SourceCode.logged = true;

            MenuFunctions.StartGameWithAccount();
        }
    }
}
