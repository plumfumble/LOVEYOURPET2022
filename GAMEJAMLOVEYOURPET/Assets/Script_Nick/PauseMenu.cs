using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    bool isPaused = false;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (isPaused)
    //        {
    //            ResumeGame();
    //        }
    //        else
    //        {
    //            PauseGame();
    //        }
    //    }
    //}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    //public void QuitGame()
    //{
    //    Application.Quit();
    //}
}
