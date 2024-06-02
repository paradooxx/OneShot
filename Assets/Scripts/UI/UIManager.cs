using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameWinScreen,
                                        gameLooseScreen;

    private void Awake()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
    }

    public void GameWinScreenActivate()
    {
        gameWinScreen.SetActive(true);
        gameLooseScreen.SetActive(false);
    }

    public void GameLooseScreenActivate()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(true);
    }

    public void Deactivate()
    {
        gameWinScreen.SetActive(false);
        gameLooseScreen.SetActive(false);
    }
}
