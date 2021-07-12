using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    // Unity method for drawing GUI in Editor
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var previousGUIState = GUI.enabled;     // Saving previous GUI enabled value

        GUI.enabled = false;                    // Disabling edit for property

        EditorGUI.PropertyField(position, property, label); // Drawing Property

        GUI.enabled = previousGUIState;         // Setting old GUI enabled value
    }
}