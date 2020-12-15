using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("N1");
    }

    public void LoadGame()
    {
        //Add LOAD GAME HERE
        Debug.Log("not yet bitch");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Info()
    {
        SceneManager.LoadScene("Information");
    }

    public void Login()
    {
        Debug.Log("HAHAHAHA NOP");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

}
