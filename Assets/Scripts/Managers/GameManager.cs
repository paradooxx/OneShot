using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        GameStatusManager.OnBulletDestroyed += GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed += GameWinStatus;
    }

    private void GameWinStatus()
    {
        uiManager.GameWinScreenActivate();
    }

    private void GameLoseStatus()
    {
        uiManager.GameLooseScreenActivate();
    }

    public void QuitGame()
    {
        /* #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif */

        uiManager.Deactivate();
    }

    private void OnDestroy() 
    {
        GameStatusManager.OnBulletDestroyed -= GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed -= GameWinStatus;
    }
}
