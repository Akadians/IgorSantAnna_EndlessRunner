using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public static TitleController instance;

    public delegate void TitleControllerHandler();

    public TitleControllerHandler OnLoadTitle;

    public void Initializations()
    {
        instance = this;        
    }

    public void LoadLeaderboard()
    {
        OnLoadTitle?.Invoke();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        Initializations();
    }
}
