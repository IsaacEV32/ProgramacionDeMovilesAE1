using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int levelID;
    [SerializeField] GameObject creditsUI;
    [SerializeField] GameObject mainMenuUI;
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelID);
    }
    public void LoadCredits()
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }
    public void LoadMainMenu()
    {
        creditsUI.SetActive(false);
        mainMenuUI.SetActive(true);
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
