using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneLoading = "MainGame";
    public string mainMenu = "MainMenu";
    public string Credits = "Credits";
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneLoading);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(Credits);
    }
}
