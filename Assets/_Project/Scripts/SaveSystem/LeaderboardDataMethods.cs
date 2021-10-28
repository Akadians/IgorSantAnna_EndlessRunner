using UnityEngine;


public class LeaderboardDataMethods : MonoBehaviour
{
    [SerializeField] private LeaderboardData _lead = new LeaderboardData();
    [SerializeField] private LeaderboardController _leadControll;

    private string _dataRecord;

    public void Initializations()
    {        
        SaveSystem.Init();
    }
    public void Save()
    {        
        _lead.leaderboard[0] = _leadControll.leaderboardScores[0];
        _lead.leaderboard[1] = _leadControll.leaderboardScores[1];
        _lead.leaderboard[2] = _leadControll.leaderboardScores[2];
        _lead.leaderboard[3] = _leadControll.leaderboardScores[3];
        _lead.leaderboard[4] = _leadControll.leaderboardScores[4];
        _lead.leaderboard[5] = _leadControll.leaderboardScores[5];
        _lead.leaderboard[6] = _leadControll.leaderboardScores[6];
        _lead.leaderboard[7] = _leadControll.leaderboardScores[7];
        _lead.leaderboard[8] = _leadControll.leaderboardScores[8];
        _lead.leaderboard[9] = _leadControll.leaderboardScores[9];

        _dataRecord = JsonUtility.ToJson(_lead);
        SaveSystem.SaveBoard(_dataRecord);
    }

    public void Load()
    {
        string _dataLoaded = SaveSystem.LoadBoard();

        if (_dataLoaded != null)
        {
            LeaderboardData leadLoaded = JsonUtility.FromJson<LeaderboardData>(_dataLoaded);
            _leadControll.leaderboardScores = leadLoaded.leaderboard;
        }
    }

    private void Start()
    {
        Initializations();
    }
}


