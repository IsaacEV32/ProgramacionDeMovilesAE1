using UnityEngine;
public class InvokePauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    bool isGamePaused = false;
    public static InvokePauseMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public bool IsGamePaused()
    {
        return isGamePaused;
    }
    public void SetGamePaused(bool isPaused)
    {
        isGamePaused = isPaused;
    }
    public void CallPauseMenu()
    {
        if (!pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            isGamePaused = true;
        }
        else if (pauseMenuUI.activeSelf)
        {
            Time.timeScale = 1f;
            isGamePaused = false;
            pauseMenuUI.SetActive(false);
        }
    }
}
