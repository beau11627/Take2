using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(UpdateAssets))]
public class CustomEditorLayout : Editor
{
    private SerializedProperty textField;
    private SerializedProperty branch;
    private bool restoreDeleted;
    private bool overwriteExistingFiles;

    private void OnEnable()
    {
        textField = serializedObject.FindProperty("commitComment"); // Replace with the name of your serialized string field
        branch = serializedObject.FindProperty("branch");
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
        if (GUILayout.Button("Pull"))
        {
            if (restoreDeleted)
            {
                scriptToDo.ExecuteGitPullRestoreDeleted();
            }
            if (overwriteExistingFiles)
            {
                scriptToDo.ExecuteGitPullOverwriteExisting();
            }
            
        }
        if (GUILayout.Button("Stash"))
        {
            scriptToDo.Stash();
        }

        restoreDeleted = GUILayout.Toggle(restoreDeleted, "Restore deleted files when pulling");
        overwriteExistingFiles = GUILayout.Toggle(overwriteExistingFiles, "overwrite existing files");
    }

}



