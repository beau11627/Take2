using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(UpdateAssets))]
public class CustomEditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UpdateAssets scriptToDo = (UpdateAssets)target;

        if (GUILayout.Button("Push to GitHub"))
        {
            scriptToDo.AddAndPushAssets();
        }
        if (GUILayout.Button("Pull from GitHub"))
        {
            scriptToDo.PerformGitPull();
        }
    }

}
