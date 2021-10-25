using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

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

        if (Game_Controller.Instance.playerAlive == true)
        {
            _TextTimer = TimeSpan.FromMinutes(minutes).ToString("mm") + ":" + TimeSpan.FromSeconds(segunds).ToString("ss");
            _HUDTimer.text = _TextTimer;
        }
    }

    public void CloseAplication()
    {
        Application.Quit();
    }
    public void CallGameOver()
    {
        _GameOverPanel.SetActive(true);        
    }

    private void Start()
    {
        Initializations();
    }
    private void Initializations()
    {
        Game_Controller.Instance.OnGameOver += CallGameOver;
    }

    private void OnDisable()
    {
        Game_Controller.Instance.OnGameOver -= CallGameOver;
    }
}
