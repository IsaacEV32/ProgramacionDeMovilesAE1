using UnityEngine;

public class HUDBehavior : MonoBehaviour
{
    int score;
    int maxScore;
    void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            score = 0;
            maxScore = 5;
        }
    }
    public int GetScore()
    {
        return score;
    }
    public int GetMaxScore()
    {
        return maxScore;
    }
    public void SumScore(int points)
    {
        score += points;
        HUD.instance.UpdateScoreText(score);
    }
    public void SumMaxScore(int points)
    {
        maxScore += points;
        HUD.instance.UpdateMaxScoreText(maxScore);
    }
}
