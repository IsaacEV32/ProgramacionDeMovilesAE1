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
    private void Start()
    {
        StartCoroutine(MoveLoop());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((interactableMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            collision.gameObject.GetComponent<IInteractablePoints>().Collect();
            collision.gameObject.SetActive(false);
        }
    }
    public Rigidbody2D GetRigidbody()
    {
        return rbPlayer;
    }
    public bool GetHasPlayerDied()
    {
        return isDead;
    }
    public void SetDeath(bool deathCondition)
    {
        isDead = deathCondition;
        rbPlayer.linearVelocity = Vector3.zero;
        StopCoroutine(MoveLoop());
        rbPlayer.gameObject.GetComponent<PlayerInput>().enabled = false;
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
