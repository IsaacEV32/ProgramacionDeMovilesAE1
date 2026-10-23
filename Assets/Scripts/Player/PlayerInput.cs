using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerBehavior playerBehavior;
    PlayerSprite playerSprite;
    [SerializeField] Transform playerTransform;
    private void Awake()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
        playerSprite = GetComponent<PlayerSprite>();
        playerSprite.GetPlayerTransform(playerTransform);
        playerSprite.SetPlayerVelocity(playerBehavior.GetRigidbody());
    }
    public void OnJump(InputAction.CallbackContext onJump)
    {
        if (onJump.started)
        {
            playerBehavior.LaunchPlayer();
        }
    }
}
