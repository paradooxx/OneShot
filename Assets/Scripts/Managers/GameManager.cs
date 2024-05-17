using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject
                    bulletGameObject,
                    enemyGameObject;


    private void Awake()
    {
        GameStatusManager.OnBulletDestroyed += GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed += GameWinStatus;
    }

    private void GameWinStatus()
    {
        Debug.Log("WINNNNNNNNNN");
        QuitGame();
    }

    private void GameLoseStatus()
    {
        Debug.Log("LOSEEEEEEEEE");
        QuitGame();
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
