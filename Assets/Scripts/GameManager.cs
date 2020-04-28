using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("first instance");
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("oopsies extras");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    
    public void PlayGame()
    {
        Debug.Log("loading level");
        SceneManager.LoadScene("World");
    }

    public void ShowControls()
    {
        Debug.Log("controls scene");
        SceneManager.LoadScene("Controls");
    }

    public void GoToMainMenu()
    {

        Debug.Log("menu");
        SceneManager.LoadScene("StartMenu");
    }

    public void ShowCredits()
    {
        Debug.Log("credits scene");
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
