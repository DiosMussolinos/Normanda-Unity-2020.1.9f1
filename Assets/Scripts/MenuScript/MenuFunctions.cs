using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{

    public void StartGameWithoutAccount()
    {
        //player.transform.position = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        SourceCode.lifePoints = SourceCode.maxLifePoints;
        SourceCode.userID = 0;
        SourceCode.logged = false;
        SceneManager.LoadScene("N1");
    }

    public void StartGameWithAccount()
    {
        SceneManager.LoadScene("N1");
    }

    public void LoadGame()
    {
        //Add LOAD GAME HERE
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
        SceneManager.LoadScene("Login");
    }

    public void CreateAccount()
    {
        SceneManager.LoadScene("CreateAccount");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        SourceCode.lifePoints = (SourceCode.maxLifePoints / 2);
    }
}
