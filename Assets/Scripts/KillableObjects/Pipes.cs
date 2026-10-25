using UnityEngine;

public class Pipes : KillableObjects
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((playerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            KillPlayer(collision.gameObject.GetComponent<PlayerInput>());
        }
    }
    public override void KillPlayer(PlayerInput player)
    {
        player.SetDeath(true);
        base.KillPlayer(player);
    }
}
