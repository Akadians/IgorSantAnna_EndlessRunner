using System;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private string _TextScore;
    [SerializeField] private string _TextTimer;
    [SerializeField] private TextMeshProUGUI _HUDScore;
    [SerializeField] private TextMeshProUGUI _HUDTimer;
    [SerializeField] private GameObject _GameOverPanel;
    public void ScoreHUDUpdate(int score)
    {
        _TextScore = score.ToString();
        _HUDScore.text = _TextScore;
    }

    public void TimerCount()
    {
        int minutes = (int)(Time.timeSinceLevelLoad / 60);
        int segunds = (int)(Time.timeSinceLevelLoad % 60);

        if (Game_Controller.GameControlerStatic._alive == true)
        {
            _TextTimer = TimeSpan.FromMinutes(minutes).ToString("mm") + ":" + TimeSpan.FromSeconds(segunds).ToString("ss");
            _HUDTimer.text = _TextTimer;
        }
    }

    public void CloseAplication()
    {
        CloseAplication();
    }
    public void CallGameOver()
    {
        _GameOverPanel.SetActive(true);
        Game_Controller.GameControlerStatic.GameOver();
    }

    private void Start()
    {
        Initializations();
    }

    private void Update()
    {


    }

    private void Initializations()
    {

    }        
}
