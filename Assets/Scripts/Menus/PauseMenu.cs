using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        InvokePauseMenu.instance.SetGamePaused(false);
        gameObject.SetActive(false);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        InvokePauseMenu.instance.SetGamePaused(false);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif DEVELOPMENT_ANDROID || RELEASE_ANDROID || DEVELOPMENT_IOS || RELEASE_IOS
        Application.Quit();
#endif
    }
}
