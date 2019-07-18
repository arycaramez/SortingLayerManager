using System.Collections.Generic;
using UnityEngine;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[System.Serializable]
public class PartControl : MonoBehaviour
{
    [HideInInspector] public CharPartsControl charPartsControl;
    [HideInInspector] public int currentTypeID = 0;
    [HideInInspector] public MeshInformation meshInfo = new MeshInformation();

    public virtual void SetMeshInfo(SortingLayerInformation sortingLayerInfo,int globalSortingLayerID,int layerBase) {
        meshInfo.SetLayerInfo(sortingLayerInfo, globalSortingLayerID, layerBase);
    }

    public virtual List<SortingLayerInformation> SettingsParts() {
        List<SortingLayerInformation> list = new List<SortingLayerInformation>();
        if (!charPartsControl) charPartsControl = this.gameObject.transform.parent.GetComponent<CharPartsControl>();
        if(charPartsControl) list = charPartsControl ? charPartsControl.editTypeParts : new List<SortingLayerInformation>();        
        return list;
    }
    
    public virtual string[] GetTagParts(){
        string[] list = new string[SettingsParts().Count];
        for (int i=0;i<list.Length;i++) {
            list[i] = SettingsParts()[i].tagPart;
        }
        return list;
    }

    public virtual string GetTagPart() {
        string[] list = GetTagParts();
        return list[currentTypeID];
    }

    public virtual void AutoFindObject()
    {
        meshInfo.obj = this.gameObject;
    }
}
[System.Serializable]
public class MeshInformation{
    public GameObject obj;
    public virtual void SetLayerInfo(SortingLayerInformation sortingLayerInfo,int globalSortingLayerID, int layerBase)
    {
        string sl_str = SortingLayer.layers[globalSortingLayerID].name;
        int sl_layer = layerBase + sortingLayerInfo.layer;

        if (GetRenderer())
        {
            GetRenderer().sortingLayerName = sl_str;
            GetRenderer().sortingOrder = sl_layer;
        }
    }
    private Renderer GetRenderer() { return obj.GetComponent<Renderer>(); }
}
