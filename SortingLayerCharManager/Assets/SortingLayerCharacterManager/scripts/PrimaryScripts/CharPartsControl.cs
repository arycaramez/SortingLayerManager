using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
[System.Serializable]
public class CharPartsControl : MonoBehaviour
{
    [HideInInspector] public int globalSortingLayerID = 0;
    [HideInInspector] public int layerBase = 0;
    //
    [HideInInspector] public List<Transform> meshTarget = new List<Transform>();
    //
    [HideInInspector] public bool collapseSlTagList = false;
    [HideInInspector] public List<string> slTagList = new List<string>();
    //
    [HideInInspector] public bool collapseMeshObjList = false;
    [HideInInspector] public List<MeshObjectElement> meshObjList = new List<MeshObjectElement>();
    
    public void ApplyList()
    {
        for (int i = 0; i < meshObjList.Count; i++)
        {
            SetSortingLayer(meshObjList[i]);
        }
    }
    //
    public void UpdateList()
    {
        List<MeshObjectElement> saveMeshObjList = new List<MeshObjectElement>();
        foreach (MeshObjectElement moe in meshObjList) saveMeshObjList.Add(moe);
        meshObjList.Clear();

        foreach (Transform t in meshTarget){
            GameObject[] arrayMeshTarget = FindRenderer(t.gameObject);
            foreach (GameObject a in arrayMeshTarget)
            {
                if(a) meshObjList.Add(new MeshObjectElement(a));
            }
        }

        for (int j = 0; j < saveMeshObjList.Count; j++)
        {
            for (int i = 0; i < meshObjList.Count; i++)
            {
                if (GameObject.Equals(meshObjList[i].meshObj,saveMeshObjList[j].meshObj))
                {
                    meshObjList[i].soTag = saveMeshObjList[j].soTag;
                }            
            }
        }
    }
    //
    private GameObject[] FindRenderer(GameObject gObj) {
        List<GameObject> selected = new List<GameObject>();
        
        //para renderizadores simples, menos os que estão vinculados ao sistema de particulas. 
        Renderer[] array1 = gObj.GetComponentsInChildren<Renderer>();
        foreach (Renderer a in array1)
        {
            if (!selected.Contains(a.gameObject) && !a.GetComponent<ParticleSystem>())
            {
                selected.Add(a.gameObject);
            }
        }
        //para sprites e animações.
        SpriteRenderer[] array2 = gObj.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer a in array2)
        {
            if (!selected.Contains(a.gameObject))
            {
                selected.Add(a.gameObject);
            }
        }
        ParticleSystem[] array3 = gObj.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem a in array3)
        {
            if (!selected.Contains(a.gameObject))
            {
                selected.Add(a.gameObject);
            }
        }
        return selected.ToArray();
    }
    //
    /*public MeshObjectElement GetMeshObjElementBySoTag(string soTag)
    {
        foreach (MeshObjectElement moe in meshObjList)
        {
            if (moe.soTag == soTag) return moe;
        }
        return null;
    }*/
    //
    public List<string> GetSortingLayerNames()
    {
        List<string> layerNames = new List<string>();
        for (int i = 0; i < SortingLayer.layers.Length; i++)
        {
            string n = SortingLayer.layers[i].name;
            layerNames.Add(n);
        }
        return layerNames;
    }
    //
    public void SetSortingLayer(MeshObjectElement meshElement)
    {
        if (meshElement != null && meshElement.meshObj != null)
        {
            Component element = element = meshElement.meshObj.GetComponent<Renderer>();

            int tagId = GetIdSubTagLayers(meshElement.soTag);

            if (tagId != -1 && tagId < slTagList.Count && slTagList.Count > 0 )
            {
                int newOrderID = GetSortingOrderByID(-tagId);
                string newName = SortingLayer.layers[globalSortingLayerID].name;
                if (element is Renderer)
                {
                    Renderer r = (Renderer)element;
                    r.sortingLayerID = SortingLayer.NameToID(newName);
                    r.sortingLayerName = newName;
                    r.sortingOrder = newOrderID;
                }
                else if (element is SpriteRenderer)
                {
                    SpriteRenderer r = (SpriteRenderer)element;
                    r.sortingLayerID = SortingLayer.NameToID(newName);
                    r.sortingLayerName = newName;
                    r.sortingOrder = newOrderID;
                }
            }
        }
    }
    //
    public int GetSortingOrderByID(int tagID)
    {
        return layerBase + tagID;
    }
    //
    public int GetIdSubTagLayers(string tagRef)
    {
        for (int i=0;i< slTagList.Count;i++)
        {
            if (slTagList[i] == tagRef) return i;
        }

        if (slTagList.Count > 0) return 0; 

        return -1;
    }
}

[System.Serializable]
public class MeshObjectElement
{
    public string soTag;
    public GameObject meshObj;
    
    public MeshObjectElement(GameObject meshObj)
    {
        this.meshObj = meshObj;
    }

    public void SetSortingOrderID(int soID)
    {
        if (meshObj) {
            object renderObj = meshObj.GetComponent<Renderer>();
            if (renderObj is Renderer)
            {
                Renderer rend = (Renderer)renderObj;
                rend.sortingOrder = soID;
            }
            else if (renderObj is SpriteRenderer)
            {
                SpriteRenderer rend = (SpriteRenderer)renderObj;
                rend.sortingOrder = soID;
            }
        }
    }
}
