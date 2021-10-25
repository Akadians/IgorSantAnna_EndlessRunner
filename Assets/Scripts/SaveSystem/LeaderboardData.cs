using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardData
{
    public int[] leaderboard;

    public LeaderboardData (LeaderBoard_Controller lead)
    {
        leaderboard = new int[10];

        leaderboard[0] = lead.leaderboardScores[0];
        leaderboard[1] = lead.leaderboardScores[1];
        leaderboard[2] = lead.leaderboardScores[2];
        leaderboard[3] = lead.leaderboardScores[3];
        leaderboard[4] = lead.leaderboardScores[4];
        leaderboard[5] = lead.leaderboardScores[5];
        leaderboard[6] = lead.leaderboardScores[6];
        leaderboard[7] = lead.leaderboardScores[7];
        leaderboard[8] = lead.leaderboardScores[8];
        leaderboard[9] = lead.leaderboardScores[9];
    }    
}


