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

    [SerializeField] private Button _leaderboardButton;

    public void Initializations()
    {
        instance = this;
        _leaderboardButton.onClick.AddListener(LoadLeaderboard);
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

    private void Awake()
    {
        Initializations();
    }
}
