using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelStatus[] levelStatus;

    private int currentLevel;

    private void Awake()
    {
        GameStatusManager.OnBulletDestroyed += GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed += GameWinStatus;

        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    //remember to assign level status sc to gamemanager go
    private void GameWinStatus()
    {
        Debug.Log("CURRENT LEVEL: " + currentLevel);
        levelStatus[currentLevel - 1].isCompleted = true;
        levelStatus[currentLevel].isUnlocked = true;
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

    
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void OnDestroy() 
    {
        GameStatusManager.OnBulletDestroyed -= GameLoseStatus;
        GameStatusManager.OnEnemyDestroyed -= GameWinStatus;
    }
}
