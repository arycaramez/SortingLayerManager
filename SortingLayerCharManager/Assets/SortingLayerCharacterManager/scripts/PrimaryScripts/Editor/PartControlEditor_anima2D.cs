using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PartControl_anima2D))]
public class PartControlEditor_anima2D : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PartControl_anima2D myScript = (PartControl_anima2D)target;

        SerializedProperty propCharPartsControl = serializedObject.FindProperty("charPartsControl");
        EditorGUILayout.PropertyField(propCharPartsControl, new GUIContent("Ref Char Part Control:"), GUILayout.Height(20));

        GUILayout.Space(10);
        myScript.currentTypeID = EditorGUILayout.Popup("Select Part:", myScript.currentTypeID, myScript.GetTagParts());
        /*
        GUILayout.Space(10);
        SerializedProperty propSpriteMeshInstance = serializedObject.FindProperty("meshInfo.spriteMeshInstance");
        EditorGUILayout.PropertyField(propSpriteMeshInstance, new GUIContent("Sprite Mesh Instance:"));
        */
        SerializedProperty propRenderer = serializedObject.FindProperty("meshInfo_anima2D.obj");
        if (propRenderer == null) propRenderer = serializedObject.FindProperty("meshInfo.obj");
        if (propRenderer != null) EditorGUILayout.PropertyField(propRenderer, new GUIContent("Obj for Set SortingLayer:"));

        GUILayout.Space(10);
        if (GUILayout.Button("Auto Find Obj"))
        {
            myScript.AutoFindObject();
        }
        serializedObject.ApplyModifiedProperties();
    }
}
