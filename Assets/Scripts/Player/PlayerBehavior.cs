using UnityEngine;
using System.Collections;
public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    bool isDead = false;
    float jumpForce = 3f;
    float speedPlayer = 50f;
    [SerializeField] LayerMask interactableMask;
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    
    public Rigidbody2D GetRigidbody()
    {
        return rbPlayer;
    }
    public bool GetHasPlayerDied()
    {
        return isDead;
    }
    public float GetJumpForce()
    {
        return jumpForce;
    }
    public float GetPlayerSpeed()
    {
        return speedPlayer;
    }
    public LayerMask GetInteractableMask()
    {
        return interactableMask;
    }
    public void SetDeathCondition(bool deathCondition)
    {
        isDead = deathCondition;
    }
    public void SetPlayerVelocity(Vector3 playerVelocity)
    {
        rbPlayer.linearVelocity = playerVelocity;
    }
}
