using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] int returnSceneIndex = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            GameManager.instance.GetComponent<SaveSystem>().Save();
            SceneManager.LoadScene(returnSceneIndex);
        }

    }
}
