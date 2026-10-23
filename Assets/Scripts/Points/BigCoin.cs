using UnityEngine;

public class BigCoin : PointsHandler
{
    public override void Collect()
    {
        HUD.instance.hudBehavior.SumScore(5);
        if (HUD.instance.hudBehavior.GetMaxScore() <= HUD.instance.hudBehavior.GetScore())
        {
            HUD.instance.hudBehavior.SumMaxScore(5);
        }
    }
}
