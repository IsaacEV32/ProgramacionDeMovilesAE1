using UnityEngine;
using UnityEngine.SceneManagement;

public class KillableObjects : MonoBehaviour, IKillable
{
    [SerializeField] protected LayerMask playerMask;
    public virtual void KillPlayer(PlayerInput player)
    {
        GameManager.instance.GetComponent<SaveSystem>().Save();
        SceneManager.LoadScene(0);
    }
}
public interface IKillable
{
    void KillPlayer(PlayerInput player);
}
