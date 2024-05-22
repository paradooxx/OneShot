using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyMovement))]
public class EnemyMovementEditor : Editor
{
    SerializedProperty pointsProperty;

    void OnEnable()
    {
        pointsProperty = serializedObject.FindProperty("movePoints");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(pointsProperty, true);

        if (GUILayout.Button("Add Selected Objects"))
        {
            AddSelectedObjects();
        }

        serializedObject.ApplyModifiedProperties();
    }

    void AddSelectedObjects()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Vector2 objPosition = new Vector2(obj.transform.position.x, obj.transform.position.y);
            pointsProperty.arraySize++;
            pointsProperty.GetArrayElementAtIndex(pointsProperty.arraySize - 1).vector2Value = objPosition;
        }
    }
}
