using UnityEngine;

public class LittleCoin : PointsHandler
{
    public override void Collect()
    {
        HUD.instance.hudBehavior.SumScore(1);
        if (HUD.instance.hudBehavior.GetMaxScore() <= HUD.instance.hudBehavior.GetScore())
        {
            HUD.instance.hudBehavior.SumMaxScore(1);
        }
    }
}
