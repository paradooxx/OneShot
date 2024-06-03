using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;

    private void Awake()
    {
        GameStatusManager.OnBulletDestroyed += GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed += GameWinStatus;
    }

    private void GameWinStatus()
    {
        uIManager.GameWinScreenActivate();
    }

    private void GameLoseStatus()
    {
        uIManager.GameLooseScreenActivate();
    }

    public void QuitGame()
    {
        /* #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif */

        uIManager.Deactivate();
    }

    private void OnDestroy() 
    {
        GameStatusManager.OnBulletDestroyed -= GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed -= GameWinStatus;
    }
}
