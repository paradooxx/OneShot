using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
