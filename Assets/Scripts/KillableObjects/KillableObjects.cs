using UnityEngine;

public class KillableObjects : MonoBehaviour, IKillable
{
    [SerializeField] protected LayerMask playerMask;
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public virtual void KillPlayer(PlayerBehavior player)
    {
        GameManager.instance.GetComponent<SaveSystem>().Save();
    }
}
public interface IKillable
{
    void KillPlayer(PlayerBehavior player);
}
