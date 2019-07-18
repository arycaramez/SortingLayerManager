using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[System.Serializable]
public class CharPartsControl : MonoBehaviour
{
    [HideInInspector] public int globalSortingLayerID = 0;
    [HideInInspector] public int layerBase = 0;
    [HideInInspector] public List<SortingLayerInformation> editTypeParts = new List<SortingLayerInformation>();
    
    private PartControl[] GetList() {
        return this.gameObject.GetComponentsInChildren<PartControl>();
    }

    public void UpdateCharMeshLayerSystem()
    {
        for (int i = 0; i < editTypeParts.Count; i++)
        {
            CheckType(editTypeParts[i]);
        }
    }

    private void CheckType(SortingLayerInformation sInfo)
    {
        PartControl[] list = GetList();
        for (int i = 0; i < list.Length; i++)
        {
            for (int j = 0; j < editTypeParts.Count; j++)
            {
                if (list[i].GetTagPart() == editTypeParts[j].tagPart)
                {
                    list[i].SetMeshInfo(editTypeParts[j], globalSortingLayerID, layerBase);
                }
            }
        }
    }

    public string[] GetSortingLaryer()
    {
        List<string> list = new List<string>();
        for (int i = 0; i < SortingLayer.layers.Length; i++)
        {
            list.Add(SortingLayer.layers[i].name);
        }
        return list.ToArray();
    }

    public void UpdateAllAutoFindMesh()
    {
        PartControl[] list = GetList();
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i]) list[i].AutoFindObject();
        }
    }

    public void AddRefThisInPartControlChildren()
    {
        PartControl[] list = GetList();
        for (int i = 0; i < list.Length; i++)
        {
            list[i].charPartsControl = this;
        }
    }
}

[System.Serializable]
public class SortingLayerInformation
{
    public string tagPart;
    public int layer;
    public SortingLayerInformation()
    {
        this.tagPart = ""; this.layer = 0;
    }
    public SortingLayerInformation(string tagPart, int layer)
    {
        this.tagPart = tagPart;
        this.layer = layer;
    }
}
