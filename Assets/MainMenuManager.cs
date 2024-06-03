using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;

    private void Awake()
    {
        levelPanel.SetActive(false);
    }

    public void LevelMenuExitClick()
    {
        levelPanel.SetActive(false);
    }

    public void ActivateLevelPanel()
    {
        levelPanel.SetActive(true);
    }
}
