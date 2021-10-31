using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public float scoreMultiplicator;
    public bool playerAlive;

    public delegate void GameControllerEventsHandler();

    public GameControllerEventsHandler OnGameOver;
    public GameControllerEventsHandler OnGamePause;
    public GameControllerEventsHandler OnGameUnpause;
    public GameControllerEventsHandler OnLoadLeaderboard;
    public GameControllerEventsHandler OnSaveNewBoard;

    [SerializeField] private UIController _UIController;
    [SerializeField] private LeaderboardController _leadboard;

    private float _currentScore;

    public void Initializations()
    {
        Debug.Log("GameController");
        instance = this;
        playerAlive = true;        
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        playerAlive = false;
        ScoreRecorder((int)_currentScore);
        OnSaveNewBoard?.Invoke();
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            OnGamePause?.Invoke();
            Time.timeScale = 0;            
            return;
        }        
    }

    public void UnpauseGame()
    {
        if (Time.timeScale == 0)
        {
            OnGameUnpause?.Invoke();
            Time.timeScale = 1;            
            return;
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayableScene");
        Time.timeScale = 1;
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    private void Awake()
    {
        Initializations();
    }

    private void Update()
    {
        ScoreCount();
        Timer();
    }    

    private void ScoreCount()
    {
        if (playerAlive == true)
        {
            OnLoadLeaderboard?.Invoke();
            _currentScore += Time.deltaTime * scoreMultiplicator;
            _UIController.ScoreHUDUpdate((int)_currentScore);
        }
    }
    private void Timer()
    {
        _UIController.TimerCount();
    }    
    private void ScoreRecorder(int currentScore)
    {
        _leadboard.LeaderboardComparations(currentScore);        
    }
}
