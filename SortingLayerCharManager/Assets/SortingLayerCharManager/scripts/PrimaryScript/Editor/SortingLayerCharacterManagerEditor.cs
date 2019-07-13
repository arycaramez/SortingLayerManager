using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SortingLayerCharacterManager))]
public class SortingLayerCharacterManagerEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        SortingLayerCharacterManager myScript = (SortingLayerCharacterManager)target;
        if (GUILayout.Button("Update Sorting Layer Info!"))
        {
            myScript.UpdateCharMeshLayerSystem();
        }

        List<string> strListSortingLayer = new List<string>();
        foreach (SortingLayer element in SortingLayer.layers) strListSortingLayer.Add(element.name);
        myScript.sortingLayerInfo.indexListID = EditorGUILayout.Popup("Global Sorting Layer:", myScript.sortingLayerInfo.indexListID, strListSortingLayer.ToArray());
        myScript.sortingLayerInfo.UpdateSortingLayerInfo(strListSortingLayer);

        DrawDefaultInspector();
    }
}
