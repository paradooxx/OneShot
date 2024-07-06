using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

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
    }

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void ReLoadLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
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
