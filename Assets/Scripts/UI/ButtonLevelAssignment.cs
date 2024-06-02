using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelAssignment : MonoBehaviour
{
    [SerializeField] private Button[] levelButton;

    private int levelIndex;

    private void Start()
    {
        for(int i = 0 ; i < levelButton.Length ; i ++)
        {
            levelIndex = i + 1;
            levelButton[i].GetComponentInChildren<TMP_Text>().text = levelIndex.ToString();
            levelButton[i].onClick.AddListener(() => LevelManager.instance.LoadLevel(levelIndex));
        }
    }
}
