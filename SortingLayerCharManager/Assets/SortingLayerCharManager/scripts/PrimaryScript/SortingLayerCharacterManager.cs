using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class SortingLayerCharacterManager : MonoBehaviour
{

    public SortingLayerInfo sortingLayerInfo;
    public int layerBase = 0;
    //
    [SerializeField] private int layerHead = -3;
    [SerializeField] private int layerTorso = -5;
    [SerializeField] private int layerMouth = -2;
    [SerializeField] private int layerEyeR = -2;
    [SerializeField] private int layerEyeL = -2;
    [SerializeField] private int layerArmR = -4;
    [SerializeField] private int layerArmL = -4;
    [SerializeField] private int layerLegR = -6;
    [SerializeField] private int layerLegL = -6;
    [SerializeField] private int layerWeapon = -1;
    [SerializeField] private int layerShield = 0;

    [SerializeField] private List<MeshLayerInfo> meshLayer = new List<MeshLayerInfo>();
    
    public void UpdateCharMeshLayerSystem() {
        for (int i = 0; i < meshLayer.Count; i++)
        {
            CheckType(meshLayer[i]);
        }
    }

    private int GetCorrectLayer(int layer) { return layerBase + layer; }
    private void CheckType(MeshLayerInfo mli) {
        switch (mli.charMeshBodyParts) {
            case CharMeshBodyParts.HEAD:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerHead));
                break;
            case CharMeshBodyParts.TORSO:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerTorso));
                break;
            case CharMeshBodyParts.ARM_L:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerArmL));
                break;
            case CharMeshBodyParts.ARM_R:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerArmR));
                break;
            case CharMeshBodyParts.LEG_L:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerLegL));
                break;
            case CharMeshBodyParts.LEG_R:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerLegR));
                break;
            case CharMeshBodyParts.EYE_L:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerEyeL));
                break;
            case CharMeshBodyParts.EYE_R:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerEyeR));
                break;
            case CharMeshBodyParts.MOUTH:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerMouth));
                break;
            case CharMeshBodyParts.WEAPON:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerWeapon));
                break;
            case CharMeshBodyParts.SHIELD:
                mli.SetLayerInfo(sortingLayerInfo, GetCorrectLayer(layerShield));
                break;
        }
    }
}

[System.Serializable]
public class MeshLayerInfo{
    public SpriteMeshInstance spriteMeshInstance;
    public Renderer renderer;
    public CharMeshBodyParts charMeshBodyParts;

    public void SetLayerInfo(SortingLayerInfo sortingLayerInfo,int correctLayer) {
        string sl_str = sortingLayerInfo.name;
        Debug.Log(sl_str);
        if (spriteMeshInstance)
        {
            spriteMeshInstance.sortingLayerName = sl_str;
            spriteMeshInstance.sortingOrder = correctLayer;
        }
        if (renderer)
        {
            renderer.sortingLayerName = sl_str;
            renderer.sortingOrder = correctLayer;
        }
    }
}
[System.Serializable]
public enum CharMeshBodyParts {
    HEAD,TORSO,ARM_R,ARM_L,LEG_R,LEG_L,EYE_R,EYE_L,MOUTH,WEAPON,SHIELD
}
[System.Serializable]
public class SortingLayerInfo {
    public int id;
    public string name;
    public int indexListID;

    public void UpdateSortingLayerInfo(List<string> strListSortingLayer) {
        id = SortingLayer.GetLayerValueFromName(strListSortingLayer[indexListID]);
        name = strListSortingLayer[indexListID];
    }
}
