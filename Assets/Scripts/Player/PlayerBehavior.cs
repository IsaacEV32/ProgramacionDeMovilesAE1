using UnityEngine;
using System.Collections;
public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    bool isDead = false;
    float jumpForce = 5f;
    float speedPlayer = 5f;
    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        StartCoroutine(MoveLoop());
    }
    public Rigidbody2D GetRigidbody()
    {
        return rbPlayer;
    }
    public void LaunchPlayer()
    {
        rbPlayer.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    IEnumerator MoveLoop()
    {
        while (!isDead)
        {
            rbPlayer.linearVelocity = new Vector2(speedPlayer, rbPlayer.linearVelocity.y);
            yield return null;
        }
    }
}
