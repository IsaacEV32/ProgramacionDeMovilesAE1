using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text maxScore;
    public HUDBehavior hudBehavior;
    public static HUD instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        hudBehavior = GetComponent<HUDBehavior>();
    }
    private void Start()
    {
        UpdateScoreText(hudBehavior.GetScore());
        UpdateMaxScoreText(hudBehavior.GetMaxScore());
    }
    public void UpdateScoreText(int _score)
    {
        score.text = "Puntuacion: " + _score.ToString();
    }
    public void UpdateMaxScoreText(int _maxScore)
    {
        maxScore.text = "Record: " + _maxScore.ToString();
    }
}
