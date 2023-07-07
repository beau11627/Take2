using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(UpdateAssets))]
public class CustomEditorField : Editor
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
        if (GUILayout.Button("Add"))
        {
            scriptToDo.ExecuteGitAdd();
        }
        if (GUILayout.Button("Push"))
        {
            UpdateAssets script = (UpdateAssets)target;
            scriptToDo.ExecuteGitPush(textField.stringValue);
         
        }
        if (GUILayout.Button("Force pull (restore deleted)"))
        {
            scriptToDo.ExecuteGitPullRestoreDeleted();
        }
        if (GUILayout.Button("Pull overwrite existing"))
        {
            scriptToDo.ExecuteGitPullOverwriteExisting();
        }

    }

}

