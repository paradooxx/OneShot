using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static int currentLevelIndex;

    [SerializeField] private LevelStatus[] levelStatus;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel(int index)
    {
        if(IsLevelUnlocked(index - 1))
        {
            SceneManager.LoadSceneAsync(index);
        }
        else
        {
            Debug.Log("Level Locked!");
        }
    }

    public void ReLoadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        /* if(levelStatus[SceneManager.GetActiveScene().buildIndex + 1].isUnlocked)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Level is Locked");
            return;
        } */
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public bool IsLevelUnlocked(int index)
    {
        if(levelStatus[index].isUnlocked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
