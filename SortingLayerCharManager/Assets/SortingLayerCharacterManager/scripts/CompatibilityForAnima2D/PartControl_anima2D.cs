using Anima2D;
using System;
using System.Collections.Generic;
using UnityEngine;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[System.Serializable]
public class PartControl_anima2D : PartControl
{
    //[HideInInspector] public CharPartsControl charPartsControl;
    //[HideInInspector] public int currentTypeID = 0;
    [HideInInspector] public MeshInformation_anima2D meshInfo_anima2D = new MeshInformation_anima2D();

    public override void SetMeshInfo(SortingLayerInformation sortingLayerInfo, int globalSortingLayerID, int layerBase)
    {
        meshInfo_anima2D.SetLayerInfo(sortingLayerInfo, globalSortingLayerID, layerBase);
    }

    public override List<SortingLayerInformation> SettingsParts() {
        List<SortingLayerInformation> list = new List<SortingLayerInformation>();
        if (!charPartsControl) charPartsControl = this.gameObject.transform.parent.GetComponent<CharPartsControl>();
        if(charPartsControl) list = charPartsControl ? charPartsControl.editTypeParts : new List<SortingLayerInformation>();        
        return list;
    }
    
    public override string[] GetTagParts(){
        string[] list = new string[SettingsParts().Count];
        for (int i=0;i<list.Length;i++) {
            list[i] = SettingsParts()[i].tagPart;
        }
        return list;
    }

    public override string GetTagPart() {
        string[] list = GetTagParts();
        return list[currentTypeID];
    }

    public override void AutoFindObject(){
        meshInfo_anima2D.obj = this.gameObject;
    }
}
[System.Serializable]
public class MeshInformation_anima2D: MeshInformation
{
    //public GameObject obj;
    public override void SetLayerInfo(SortingLayerInformation sortingLayerInfo,int globalSortingLayerID, int layerBase)
    {
        string sl_str = SortingLayer.layers[globalSortingLayerID].name;
        int sl_layer = layerBase + sortingLayerInfo.layer;

        SpriteMeshInstance smi = GetSpriteMeshInstance();
        Renderer rend = GetRenderer();

        if (smi) {
            smi.sortingLayerName = sl_str;
            smi.sortingOrder = sl_layer;
        }else if (rend) {
            rend.sortingLayerName = sl_str;
            rend.sortingOrder = sl_layer;
        }
    }
    private Renderer GetRenderer() { return obj.GetComponent<Renderer>(); }
    private SpriteMeshInstance GetSpriteMeshInstance() { return obj.GetComponent<SpriteMeshInstance>(); }
}
