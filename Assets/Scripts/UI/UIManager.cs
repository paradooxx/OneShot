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
                                    buttonRetry;

    private void Awake()
    {
        /* gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
        mainMenuButton.SetActive(false); */
    }

    private void Start()
    {
        Debug.Log(LevelManager.instance);
        buttonMainMenu?.onClick.AddListener(() => LevelManager.instance.LoadLevel(0));
        buttonRetry?.onClick.AddListener(() => LevelManager.instance.ReLoadLevel());
    }

    public void GameWinScreenActivate()
    {
        gameWinScreen.SetActive(true);
        gameLooseScreen.SetActive(false);
        mainMenuButton.SetActive(true);
    }

    public void GameLooseScreenActivate()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(true);
        mainMenuButton.SetActive(true);
    }

    public void Deactivate()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
    }
}
