using System.IO;
using UnityEngine;

public class LeaderboardData : MonoBehaviour
{
    [SerializeField] private int[] leaderboard = new int[10];

    [SerializeField] private LeaderBoard_Controller _leadControll;

    private string _dataRecord;

    public void Initializations()
    {               
        SaveSystem.Init();        
    }
    public void Save()
    {
        leaderboard[0] = _leadControll.leaderboardScores[0];
        leaderboard[1] = _leadControll.leaderboardScores[1];
        leaderboard[2] = _leadControll.leaderboardScores[2];
        leaderboard[3] = _leadControll.leaderboardScores[3];
        leaderboard[4] = _leadControll.leaderboardScores[4];
        leaderboard[5] = _leadControll.leaderboardScores[5];
        leaderboard[6] = _leadControll.leaderboardScores[6];
        leaderboard[7] = _leadControll.leaderboardScores[7];
        leaderboard[8] = _leadControll.leaderboardScores[8];
        leaderboard[9] = _leadControll.leaderboardScores[9];

        _dataRecord = JsonUtility.ToJson(this);
        SaveSystem.SaveBoard(_dataRecord);
    }

    public void Load()
    {
        string _dataLoaded = SaveSystem.LoadBoard();

        if (_dataLoaded != null)
        {
            LeaderboardData lead = JsonUtility.FromJson<LeaderboardData>(_dataLoaded);
            _leadControll.LoadLeadBoard(lead.leaderboard);
        }
    }

    private void Awake()
    {
        Initializations();
    }
}


