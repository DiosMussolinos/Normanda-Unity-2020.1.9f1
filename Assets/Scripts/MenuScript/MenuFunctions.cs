using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFunctions : MonoBehaviour
{

    public void StartGame()
    {
        //player.transform.position = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        SourceCode.lifePoints = SourceCode.maxLifePoints;
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

    public void TryAgain()
    {
        SourceCode.lifePoints = (SourceCode.maxLifePoints / 2);
    }
}
