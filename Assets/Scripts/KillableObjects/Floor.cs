using UnityEngine;

public class Floor : KillableObjects
{
    [SerializeField] Transform playerPosition;
    Rect safeArea;
    Camera cam;
    PlayerInput playerInput;
    private void Start()
    {
        safeArea = new Rect(Screen.safeArea.x, Screen.safeArea.y, Screen.safeArea.width, Screen.safeArea.height);
        cam = Camera.main;
        playerInput = playerPosition.GetComponent<PlayerInput>();
    }
    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(playerPosition.position);
        if (screenPos.y <= safeArea.yMin - 50f)
        {
            KillPlayer(playerInput);
        }
    }
    public override void KillPlayer(PlayerInput player)
    {
        player.SetDeath(true);
        base.KillPlayer(player);
    }
}
