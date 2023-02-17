using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;
using SortingLayerManager;
//Author: Ary Guilherme Pires Caramez. https://www.artstation.com/arycaramez
namespace SortingLayerManager.Anima2D
{
    [System.Serializable]
    public class SortingLayerManagerForAnima2D : AbstractSortingLayerManager,ISortingLayerManager
    {
        /*[HideInInspector] public int globalSortingLayerID = 0;
        [HideInInspector] public int layerBase = 0;
       
        [HideInInspector] public List<Transform> meshTarget = new List<Transform>();
       
        [HideInInspector] public bool collapseSlTagList = false;
        [HideInInspector] public List<string> slTagList = new List<string>();
        
        [HideInInspector] public bool collapseMeshObjList = false;*/

        [HideInInspector] 
        public List<MeshObjectElementForAnima2D> meshObjList = new List<MeshObjectElementForAnima2D>();

        /*public void ApplyList()
        {
            for (int i = 0; i < meshObjList.Count; i++)
            {
                SetSortingLayer(meshObjList[i]);
            }
        }*/
        //
        public override void UpdateList()
        {

            List<MeshObjectElementForAnima2D> saveMeshObjList = new List<MeshObjectElementForAnima2D>();
            foreach (MeshObjectElementForAnima2D moe in meshObjList) saveMeshObjList.Add(moe);
            meshObjList.Clear();

            foreach (Transform t in meshTarget)
            {
                GameObject[] arrayMeshTarget = FindRenderer(t.gameObject);
                foreach (GameObject a in arrayMeshTarget)
                {
                    if (a) meshObjList.Add(new MeshObjectElementForAnima2D(a));
                }
            }

            for (int j = 0; j < saveMeshObjList.Count; j++)
            {
                for (int i = 0; i < meshObjList.Count; i++)
                {
                    if (GameObject.Equals(meshObjList[i].meshObj, saveMeshObjList[j].meshObj))
                    {
                        meshObjList[i].soTag = saveMeshObjList[j].soTag;
                    }
                }
            }
        }

        public override GameObject[] FindRenderer(GameObject gObj)
        {
            List<GameObject> selected = new List<GameObject>();
            //componente de renderização do anima 2D.
            SpriteMeshInstance[] array = gObj.GetComponentsInChildren<SpriteMeshInstance>();
            foreach (SpriteMeshInstance a in array)
            {
                if (!selected.Contains(a.gameObject)) selected.Add(a.gameObject);
            }
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

        /*public List<string> GetSortingLayerNames()
        {
            List<string> layerNames = new List<string>();
            for (int i = 0; i < SortingLayer.layers.Length; i++)
            {
                string n = SortingLayer.layers[i].name;
                layerNames.Add(n);
            }
            return layerNames;
        }*/

        public override void SetSortingLayer(IMeshObjectElement meshElement)
        {
            if (meshElement is MeshObjectElementForAnima2D _meshElement)
            {
                if (meshElement != null && _meshElement.meshObj != null)
                {
                    Component element = _meshElement.meshObj.GetComponent<SpriteMeshInstance>();
                    if (element == null) element = _meshElement.meshObj.GetComponent<Renderer>();

                    int tagId = GetIdSubTagLayers(_meshElement.soTag);

                    if (tagId != -1 && tagId < slTagList.Count && slTagList.Count > 0)
                    {
                        int newOrderID = GetSortingOrderByID(-tagId);
                        string newName = SortingLayer.layers[globalSortingLayerID].name;
                        if (element is SpriteMeshInstance)
                        {
                            SpriteMeshInstance smi = (SpriteMeshInstance)element;
                            smi.sortingLayerID = newOrderID;
                            smi.sortingLayerName = newName;
                            smi.sortingOrder = newOrderID;
                        }
                        else if (element is Renderer)
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
        }

        /*public int GetSortingOrderByID(int tagID)
        {
            return layerBase + tagID;
        }
        */

        /*public int GetIdSubTagLayers(string tagRef)
        {
            for (int i = 0; i < slTagList.Count; i++)
            {
                if (slTagList[i] == tagRef) return i;
            }

            if (slTagList.Count > 0) return 0;

            return -1;
        }*/
    }
}