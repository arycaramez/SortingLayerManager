using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[CustomEditor(typeof(CharPartsControl))]
public class CharPartsControlEditor : Editor
{
    private CharPartsControl MyScript() { return (CharPartsControl)target; }
    private ReorderableList settingsPartsList;
    
    public void OnEnable() {
        //
        settingsPartsList = new ReorderableList(serializedObject, serializedObject.FindProperty("editTypeParts"), true, true, true, true);
        //callback

        settingsPartsList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(new Rect(rect.x+15, rect.y, rect.width, rect.height), "Tag");
            EditorGUI.LabelField(new Rect(rect.x + (rect.width/2)+5, rect.y, rect.width, rect.height), "Add in Layer Base");
        };

        settingsPartsList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = settingsPartsList.serializedProperty.GetArrayElementAtIndex(index);

            EditorGUI.PropertyField( new Rect(rect.x, rect.y, rect.width /2, rect.height), 
                element.FindPropertyRelative("tagPart"), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x+(rect.width/2), rect.y, rect.width/2, rect.height),
                element.FindPropertyRelative("layer"), GUIContent.none);
        };
    }

    public override void OnInspectorGUI()
    {
        CharPartsControl myScript = MyScript();

        DrawDefaultInspector();

        GUILayout.Space(5);
        if (GUILayout.Button("Update All Auto Find Mesh")) {
            myScript.UpdateAllAutoFindMesh();
        }
        if (GUILayout.Button("Add Ref This in 'PartControl' Children")) {
            myScript.AddRefThisInPartControlChildren();
        }

        GUILayout.Space(10);
        myScript.globalSortingLayerID = EditorGUILayout.Popup("Global Sorting Layer:", myScript.globalSortingLayerID, myScript.GetSortingLaryer());

        GUILayout.Space(10);
        myScript.layerBase = EditorGUILayout.IntField("Layer Base:", myScript.layerBase);

        GUILayout.Space(10);
        GUILayout.Label("Character Parts Settings (Total: "+myScript.editTypeParts.Count+"):",EditorStyles.boldLabel);
        serializedObject.Update();
        settingsPartsList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);

        GUILayout.Space(10);
        if (GUILayout.Button("Apply Settings"))
        {
            myScript.UpdateCharMeshLayerSystem();
        }
    }

    private void AddNewPart() {
        MyScript().editTypeParts.Add(new SortingLayerInformation());
    }
    private void DelPart(int id)
    {
        MyScript().editTypeParts.RemoveAt(id);
    }

}
