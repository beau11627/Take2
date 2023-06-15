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

        if (GUILayout.Button("Custom Button"))
        {
            scriptToDo.AddAndPushAssets();
        }
    }
}
