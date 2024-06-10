using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPanel;

    [SerializeField] private Button buttonStart,
                                    buttonLevelSelect,
                                    buttonLevelMenuExit;

    private void Awake()
    {
        levelPanel.SetActive(false);
    }

    private void Start()
    {
        buttonStart?.onClick.AddListener(() => LevelManager.instance.StartLevel());
        buttonLevelSelect?.onClick.AddListener(() => ActivateLevelPanel());
        buttonLevelMenuExit?.onClick.AddListener(() => LevelMenuExitClick());
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
