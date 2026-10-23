using UnityEngine;

public class Pipes : KillableObjects
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            KillPlayer(collision.gameObject.GetComponent<PlayerBehavior>());
        }
    }
    public override void KillPlayer(PlayerBehavior player)
    {
        player.SetDeath(true);
    }
}
