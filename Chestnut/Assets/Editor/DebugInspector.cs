using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(GameDebug))]
class DebugInspector : Editor {


    public override void OnInspectorGUI()
    {

        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("integers"),true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("vectors"),true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("objects"),true);
        serializedObject.ApplyModifiedProperties();


    }


}
