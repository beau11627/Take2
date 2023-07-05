using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(UpdateAssets))]
public class CustomEditorButton : Editor
{
    private SerializedProperty textField;
    
    private void OnEnable()
    {
        textField = serializedObject.FindProperty("commitComment"); // Replace with the name of your serialized string field
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UpdateAssets scriptToDo = (UpdateAssets)target;

        if (GUILayout.Button("Push to GitHub"))
        {
            UpdateAssets script = (UpdateAssets)target;
            script.AddAndPushAssets(textField.stringValue);
        }
        if (GUILayout.Button("Pull from GitHub"))
        {
            scriptToDo.PerformGitPull();
        }

        serializedObject.Update();

        DrawDefaultInspector();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Custom Section", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(textField);


        serializedObject.ApplyModifiedProperties();
    }

}

