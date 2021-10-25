using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard_Controller : MonoBehaviour
{
    public TextMeshProUGUI[] leaderboardPositions = new TextMeshProUGUI[10];
    public int[] leaderboardScores = new int[10];

    [SerializeField] private Image[] _colorLine = new Image[10];
    [SerializeField] private LeaderboardData _dataLead;

    public void Initializations()
    {
        LeaderboardWriter();
    }
    public void LeaderboardComparations(int score)
    {
        if (score > leaderboardScores[9] && score <= leaderboardScores[8])
        {
            leaderboardScores[9] = score;
            _colorLine[9].color = Color.green;
            return;
        }

        if (score > leaderboardScores[8] && score <= leaderboardScores[7])
        {
            leaderboardScores[9] = leaderboardScores[8];
            leaderboardScores[8] = score;
            _colorLine[8].color = Color.green;
            return;
        }

        if (score > leaderboardScores[7] && score <= leaderboardScores[6])
        {
            leaderboardScores[8] = leaderboardScores[7];
            leaderboardScores[7] = score;
            _colorLine[7].color = Color.green;
            return;
        }

        if (score > leaderboardScores[6] && score <= leaderboardScores[5])
        {
            leaderboardScores[7] = leaderboardScores[6];
            leaderboardScores[6] = score;
            _colorLine[6].color = Color.green;
            return;
        }

        if (score > leaderboardScores[5] && score <= leaderboardScores[4])
        {
            leaderboardScores[6] = leaderboardScores[5];
            leaderboardScores[5] = score;
            _colorLine[5].color = Color.green;
            return;
        }

        if (score > leaderboardScores[4] && score <= leaderboardScores[3])
        {
            leaderboardScores[5] = leaderboardScores[4];
            leaderboardScores[4] = score;
            _colorLine[4].color = Color.green;
            return;
        }

        if (score > leaderboardScores[3] && score <= leaderboardScores[2])
        {
            leaderboardScores[4] = leaderboardScores[3];
            leaderboardScores[3] = score;
            _colorLine[3].color = Color.green;
            return;
        }

        if (score > leaderboardScores[2] && score <= leaderboardScores[1])
        {
            leaderboardScores[3] = leaderboardScores[2];
            leaderboardScores[2] = score;
            _colorLine[2].color = Color.green;
            return;
        }

        if (score > leaderboardScores[1] && score <= leaderboardScores[0])
        {
            leaderboardScores[2] = leaderboardScores[1];
            leaderboardScores[1] = score;
            _colorLine[1].color = Color.green;
            return;
        }

        if (score > leaderboardScores[0])
        {
            leaderboardScores[1] = leaderboardScores[0];
            leaderboardScores[0] = score;
            _colorLine[0].color = Color.green;
            return;
        }

        LeaderboardWriter();
        _dataLead = new LeaderboardData(this);
    }        

    private void Start()
    {
        Initializations();       
    }    
    private void LeaderboardWriter()
    {
        leaderboardPositions[9].text = leaderboardScores[9].ToString();
        leaderboardPositions[8].text = leaderboardScores[8].ToString();
        leaderboardPositions[7].text = leaderboardScores[7].ToString();
        leaderboardPositions[6].text = leaderboardScores[6].ToString();
        leaderboardPositions[5].text = leaderboardScores[5].ToString();
        leaderboardPositions[4].text = leaderboardScores[4].ToString();
        leaderboardPositions[3].text = leaderboardScores[3].ToString();
        leaderboardPositions[2].text = leaderboardScores[2].ToString();
        leaderboardPositions[1].text = leaderboardScores[1].ToString();
        leaderboardPositions[0].text = leaderboardScores[0].ToString();
    }        
}
