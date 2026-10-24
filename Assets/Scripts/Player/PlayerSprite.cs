using UnityEngine;
using System.Collections;
public class PlayerSprite : MonoBehaviour
{
    Transform playerSprite;
    Rigidbody2D playerVelocity;
    public void Start()
    {
        StartCoroutine(RotatePlayer());
    }
    public void SetPlayerVelocity(Rigidbody2D _playerVelocity)
    {
        playerVelocity = _playerVelocity;
    }
    public void GetPlayerTransform(Transform playerRotation)
    {
        playerSprite = playerRotation;
    }
    IEnumerator RotationOfPlayer(Quaternion endValue, float duration)
    {
        if (playerSprite.rotation == endValue)
        {
            yield return null;
        }
        float time = 0;
        Quaternion startValue = playerSprite.rotation;

        while (time < duration)
        {
            playerSprite.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        playerSprite.rotation = endValue;
    }
    IEnumerator RotatePlayer()
    {
        Vector3 targetRotation = Vector3.zero;
        while (true)
        {
            if (playerVelocity.linearVelocity.y < 0)
            {
                targetRotation = new Vector3(0, 0, -90);
            }
            else
            {
                targetRotation = new Vector3(0, 0, 20);
            }
            yield return StartCoroutine(RotationOfPlayer(Quaternion.Euler(targetRotation), 0.1f));

        }
    }
}
