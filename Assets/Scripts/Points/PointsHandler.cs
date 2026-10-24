using UnityEngine;

public class PointsHandler : MonoBehaviour, IInteractablePoints
{
    public virtual void Collect()
    {
        
    }
}
public interface IInteractablePoints
{
    void Collect();
}
