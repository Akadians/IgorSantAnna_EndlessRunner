using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour

{
    public static Game_Controller Instance;

    public float scoreMultiplicator;
    public bool playerAlive;

    public delegate void GameControllerEventsHandler();
    public GameControllerEventsHandler OnGameOver;
    public GameControllerEventsHandler OnGamePause;
    public GameControllerEventsHandler OnGameUnpause;    

    [SerializeField] private UI_Controller _UIController;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private LeaderBoard_Controller _leadboard;

    private float _currentScore;

    public void Initializations()
    {
        Instance = this;
        playerAlive = true;        
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        playerAlive = false;
        ScoreRecorder((int)_currentScore);
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

    private void Start()
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
