using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PartControl))]
public class PartControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PartControl myScript = (PartControl)target;

        SerializedProperty propCharPartsControl = serializedObject.FindProperty("charPartsControl");
        EditorGUILayout.PropertyField(propCharPartsControl, new GUIContent("Ref Char Part Control:"), GUILayout.Height(20));

        GUILayout.Space(10);
        myScript.currentTypeID = EditorGUILayout.Popup("Select Part:", myScript.currentTypeID, myScript.GetTagParts());
        /*
        GUILayout.Space(10);
        SerializedProperty propSpriteMeshInstance = serializedObject.FindProperty("meshInfo.spriteMeshInstance");
        EditorGUILayout.PropertyField(propSpriteMeshInstance, new GUIContent("Sprite Mesh Instance:"));
        */
        SerializedProperty propRenderer = serializedObject.FindProperty("meshInfo.obj");
        EditorGUILayout.PropertyField(propRenderer, new GUIContent("Obj Ref of Layer:"));

        GUILayout.Space(10);
        if (GUILayout.Button("Auto Find Obj"))
        {
            myScript.AutoFindObject();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
