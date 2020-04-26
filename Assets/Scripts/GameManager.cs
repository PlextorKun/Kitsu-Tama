using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static bool exists = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            exists = true;
            return;
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        if (exists)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            GoToMainMenu();
        }
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
