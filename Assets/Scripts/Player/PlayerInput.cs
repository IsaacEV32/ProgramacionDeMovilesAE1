using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PlayerInput : MonoBehaviour
{
    PlayerBehavior playerBehavior;
    PlayerSprite playerSprite;
    [SerializeField] Transform playerTransform;
    private void Awake()
    {
        playerBehavior = GetComponent<PlayerBehavior>();
        playerSprite = GetComponent<PlayerSprite>();

    }
    private void Start()
    {
        playerSprite.GetPlayerTransform(playerTransform);
        playerSprite.SetPlayerVelocity(playerBehavior.GetRigidbody());
        StartCoroutine(MoveLoop());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerBehavior.GetInteractableMask().value & (1 << collision.gameObject.layer)) != 0)
        {
            collision.gameObject.GetComponent<IInteractablePoints>().Collect();
            collision.gameObject.SetActive(false);
        }
    }
    public void OnJump(InputAction.CallbackContext onJump)
    {
        if (onJump.started && !playerBehavior.GetHasPlayerDied())
        {
            LaunchPlayer();
        }
    }
    public void SetDeath(bool deathCondition)
    {
        playerBehavior.SetDeathCondition(deathCondition);
        playerBehavior.SetPlayerVelocity(Vector2.zero);
        StopCoroutine(MoveLoop());
        this.enabled = false;
    }
    public void LaunchPlayer()
    {
        playerBehavior.SetPlayerVelocity(new Vector2(playerBehavior.GetRigidbody().linearVelocity.x, 0));
        playerBehavior.GetRigidbody().AddForce(transform.up * playerBehavior.GetJumpForce(), ForceMode2D.Impulse);
    }
    IEnumerator MoveLoop()
    {
        while (!playerBehavior.GetHasPlayerDied())
        {
            playerBehavior.SetPlayerVelocity
                (new Vector2(playerBehavior.GetPlayerSpeed() * Time.fixedDeltaTime,
                playerBehavior.GetRigidbody().linearVelocity.y));
            yield return null;
        }
    }
}
