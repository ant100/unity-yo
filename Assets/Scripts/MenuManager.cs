using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject UIGamePaused = null;
    [SerializeField] string IntroLevel = null;  

    public void PauseGame()
    {
        if (Time.timeScale > 0f)
        {
            UIGamePaused.SetActive(true); // this brings up the pause UI
            Time.timeScale = 0f; // this pauses the game action
        }
        else
        {
            Time.timeScale = 1f; // this unpauses the game action (ie. back to normal)
            UIGamePaused.SetActive(false); // remove the pause UI
        }
    }

    public void ReturnMenu()
    {
        Debug.Log("click");
        if (Time.timeScale < 1f)
            Time.timeScale = 1f; // this unpauses the game action (ie. back to normal)
        SceneManager.LoadScene(IntroLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
