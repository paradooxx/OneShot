using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
