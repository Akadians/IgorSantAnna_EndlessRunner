using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour

{
    public static Game_Controller GameControlerStatic;

    public float scoreMultiplicator;
    public bool playerAlive;    

    [SerializeField] private UI_Controller _UIController;
    [SerializeField] private GameObject _PausePanel;
    [SerializeField] private LeaderBoard_Controller _leadboard;

    private float _currentScore;


    public void GameOver()
    {        
        playerAlive = false;
        ScoreRecorder((int)_currentScore);
        Time.timeScale = 0;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            _PausePanel.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _PausePanel.SetActive(false);
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
    private void Initializations()
    {
        GameControlerStatic = this;
        playerAlive = true;
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
