using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[Header("MainPanels")]
    [SerializeField] private GameObject gameWinScreen,
                                        gameLooseScreen,
                                        mainMenuButton;

    //[Tooltip("Buttons")]
    [SerializeField] private Button buttonMainMenu,
                                    buttonRetry,
                                    buttonReplay,
                                    buttonNextLevel;

    private void Awake()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    private void Start()
    {
        Debug.Log(LevelManager.instance);
        buttonMainMenu?.onClick.AddListener(() => LevelManager.instance.LoadLevel(0));
        buttonRetry?.onClick.AddListener(() => LevelManager.instance.ReLoadLevel());
        buttonReplay?.onClick.AddListener(() => LevelManager.instance.ReLoadLevel());
        buttonNextLevel?.onClick.AddListener(() => LevelManager.instance.LoadNextLevel());
    }

    public void GameWinScreenActivate()
    {
        gameWinScreen.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void GameLooseScreenActivate()
    {
        gameLooseScreen.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void Deactivate()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
    }
}
