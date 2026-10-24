using UnityEngine;

public class Floor : KillableObjects
{
    [SerializeField] Transform playerPosition;
    Rect safeArea;
    Camera cam;
    PlayerBehavior playerBehavior;
    private void Start()
    {
        safeArea = new Rect(Screen.safeArea.x, Screen.safeArea.y, Screen.safeArea.width, Screen.safeArea.height);
        cam = Camera.main;
        playerBehavior = playerPosition.GetComponent<PlayerBehavior>();
    }
    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(playerPosition.position);
        if (screenPos.y <= safeArea.yMin - 50f)
        {
            KillPlayer(playerBehavior);
        }
    }
    public override void KillPlayer(PlayerBehavior player)
    {
        player.SetDeath(true);
        base.KillPlayer(player);
    }
}
