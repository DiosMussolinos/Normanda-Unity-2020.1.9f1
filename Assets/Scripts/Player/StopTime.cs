using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopTime : MonoBehaviour
{

    public static bool gamePaused = false;

    public GameObject pauseUI;
    public GameObject optionsPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume()
    {

        pauseUI.SetActive(false);
        optionsPause.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;

    }

    public void Options()
    {
        pauseUI.SetActive(false);
        optionsPause.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void OptionsBack()
    {
        pauseUI.SetActive(true);
        optionsPause.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }


    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        optionsPause.SetActive(false);
    }

}
