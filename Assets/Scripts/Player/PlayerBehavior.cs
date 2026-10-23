using UnityEngine;
using System.Collections;
public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    bool isDead = false;
    float jumpForce = 5f;
    float speedPlayer = 10f;
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
        rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, 0);
        rbPlayer.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    IEnumerator MoveLoop()
    {
        while (!isDead)
        {
            rbPlayer.linearVelocity = new Vector2(speedPlayer * Time.fixedDeltaTime, rbPlayer.linearVelocity.y);
            yield return null;
        }
    }
}
