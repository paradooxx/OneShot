using UnityEngine;

[CreateAssetMenu(fileName = "Level Status", menuName = "Scriptable Objects/Level Status")]
public class LevelStatus : ScriptableObject
{
    public int levelNumber = 1;

    public bool isUnlocked,
                isCompleted;

}
