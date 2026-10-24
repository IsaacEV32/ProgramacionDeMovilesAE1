using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SaveSystem saveSystem;
    [SerializeField] TMP_Text applicationVersionText;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
#if DEVELOPMENT_ANDROID
        this.gameObject.AddComponent(typeof(SaveSystemAndroid));
        saveSystem = GetComponent<SaveSystem>();
        applicationVersionText.text = "Platform Version: " + Application.platform + " Version: " + Application.version;
#elif RELEASE_ANDROID
        this.gameObject.AddComponent(typeof(SaveSystemAndroid));
        saveSystem = GetComponent<SaveSystem>();
        Destroy(applicationVersionText.gameObject);
#elif DEVELOPMENT_IOS
        this.gameObject.AddComponent(typeof(SaveSystemiOS));
        saveSystem = GetComponent<SaveSystem>();
        applicationVersionText.text = "Platform Version: " + Application.platform + " Version: " + Application.version;
#elif RELEASE_IOS
        this.gameObject.AddComponent(typeof(SaveSystemiOS));
        saveSystem = GetComponent<SaveSystem>();
        Destroy(applicationVersionText.gameObject);
#elif UNITY_EDITOR
        this.gameObject.AddComponent(typeof(SaveSystemAndroid));
        saveSystem = GetComponent<SaveSystem>();
        applicationVersionText.text = "Platform Version: " + Application.platform + " Version: " + Application.version;
#endif

    }
}
