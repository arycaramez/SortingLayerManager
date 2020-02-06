using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[CustomEditor(typeof(CharPartsControl))]
public class CharPartsControlEditor : Editor
{
    
    private CharPartsControl MyScript() { return (CharPartsControl)target; }
    private ReorderableList rl_meshObjList;
    private ReorderableList rl_subTagLayers;
    private ReorderableList rl_meshTarget;

    public void OnEnable() {
        CharPartsControl myScript = MyScript();
        //cria a lista reordenavel
        rl_meshObjList = 
            new ReorderableList(
                serializedObject, 
                serializedObject.FindProperty("meshObjList"), 
                true, true, true, true);
        //callback        
        rl_meshObjList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Mesh Object List");
        };
        //
        rl_meshObjList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = rl_meshObjList.serializedProperty.GetArrayElementAtIndex(index);

            var slTag = element.FindPropertyRelative("soTag");
            var meshObj = element.FindPropertyRelative("meshObj");

            meshObj.objectReferenceValue = 
                (GameObject)EditorGUI.ObjectField(
                    new Rect(rect.x, rect.y, 
                    EditorGUIUtility.currentViewWidth * 0.4f, EditorGUIUtility.singleLineHeight),
                    meshObj.objectReferenceValue, typeof(GameObject),true);

            int idSubTagLayers = myScript.GetIdSubTagLayers(slTag.stringValue);
            if (idSubTagLayers >= 0)
            {
                float cWidth = EditorGUIUtility.currentViewWidth * 0.4f;
                idSubTagLayers =
                    EditorGUI.Popup(new Rect(rect.x + cWidth, rect.y,
                        cWidth, EditorGUIUtility.singleLineHeight),
                            idSubTagLayers, myScript.slTagList.ToArray());

                slTag.stringValue = myScript.slTagList[idSubTagLayers];
            }
            else
            {
                if(slTag.stringValue != "") slTag.stringValue = "";
            }
        };
        //
        rl_subTagLayers =
            new ReorderableList(
                serializedObject,
                serializedObject.FindProperty("slTagList"),
                true, true, true, true);
        //callback        
        rl_subTagLayers.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Sub Tag List");
        };

        rl_subTagLayers.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = rl_subTagLayers.serializedProperty.GetArrayElementAtIndex(index);

            element.stringValue = 
                EditorGUI.TextField( new Rect(rect.x, rect.y,
                    EditorGUIUtility.currentViewWidth * 0.8f, EditorGUIUtility.singleLineHeight),
                    "ID:"+index, element.stringValue);
        };
        //myScript.meshTarget
        rl_meshTarget =
            new ReorderableList(
                serializedObject,
                serializedObject.FindProperty("meshTarget"),
                true, true, true, true);
        //
        rl_meshTarget.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Mesh Target");
        };
        //
        rl_meshTarget.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = rl_meshTarget.serializedProperty.GetArrayElementAtIndex(index);

            element.objectReferenceValue = (Transform)EditorGUI.ObjectField(new Rect(rect.x, rect.y,
                EditorGUIUtility.currentViewWidth * 0.8f, EditorGUIUtility.singleLineHeight),
                element.objectReferenceValue, typeof(Transform),true);
        };
    }

    public override void OnInspectorGUI()
    {
        CharPartsControl myScript = MyScript();

        DrawDefaultInspector();

        GUILayout.Space(5);
        
        List<string> sln = new List<string>();
        myScript.globalSortingLayerID = 
            EditorGUILayout.Popup(
                "Global Sorting Layer:",
                myScript.globalSortingLayerID,
                myScript.GetSortingLayerNames().ToArray());

        myScript.layerBase = EditorGUILayout.IntField("Layer Base:", myScript.layerBase);

        GUILayout.Space(10);
        myScript.collapseSlTagList = EditorGUILayout.Toggle("Collapse Tag List:", myScript.collapseSlTagList);
        if (!myScript.collapseSlTagList) {
            serializedObject.Update();
            rl_subTagLayers.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
            GUILayout.Space(10);
        }
        
        myScript.collapseMeshObjList = EditorGUILayout.Toggle("Collapse Mesh Obj List:", myScript.collapseMeshObjList);
        if (!myScript.collapseMeshObjList)
        {

            serializedObject.Update();
            rl_meshTarget.DoLayoutList();
            serializedObject.ApplyModifiedProperties();

            GUILayout.Space(10);

            serializedObject.Update();
            rl_meshObjList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        GUILayout.Space(10);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Find All Meshes"))
        {
            if (EditorUtility.DisplayDialog("Confirmation",
                "Are you sure you want to automatically update mesh objects?",
                "YES", "NO"))
            {
                myScript.UpdateList();
            }
        }
        if (GUILayout.Button("Apply Settings"))
        {
            if (EditorUtility.DisplayDialog("Confirmation",
                "Do you want to apply changes to the sorting layers?",
                "YES", "NO"))
            {
                myScript.ApplyList();
            }
        }
        EditorGUILayout.EndHorizontal();
    }
}
