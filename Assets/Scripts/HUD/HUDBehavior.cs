using UnityEngine;

public class HUDBehavior : MonoBehaviour
{
    int score;
    int maxScore;
    void Start()
    {
        score = 0;
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            maxScore = 0;
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
    public void SetData(SaveSystemData _data)
    {
        maxScore = _data.maxScore;
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
