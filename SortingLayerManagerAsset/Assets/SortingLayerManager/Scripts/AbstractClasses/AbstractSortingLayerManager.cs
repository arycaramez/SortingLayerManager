using SortingLayerManager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SortingLayerManager
{
    public abstract class AbstractSortingLayerManager : MonoBehaviour
    {
        [HideInInspector] public int globalSortingLayerID = 0;
        [HideInInspector] public int layerBase = 0;

        [HideInInspector] public List<Transform> meshTarget = new List<Transform>();

        [HideInInspector] public bool collapseSlTagList = false;
        [HideInInspector] public List<string> slTagList = new List<string>();

        [HideInInspector] public bool collapseMeshObjList = false;

        public virtual void ApplyList()
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateList()
        {
            throw new NotImplementedException();
        }

        public virtual GameObject[] FindRenderer(GameObject gObj)
        {
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

        public virtual int GetIdSubTagLayers(string tagRef)
        {
            for (int i = 0; i < slTagList.Count; i++)
            {
                if (slTagList[i] == tagRef) return i;
            }

            if (slTagList.Count > 0) return 0;

            return -1;
        }

        public virtual List<string> GetSortingLayerNames()
        {
            List<string> layerNames = new List<string>();
            for (int i = 0; i < SortingLayer.layers.Length; i++)
            {
                string n = SortingLayer.layers[i].name;
                layerNames.Add(n);
            }
            return layerNames;
        }

        public virtual int GetSortingOrderByID(int tagID)
        {
            return layerBase + tagID;
        }

        public virtual void SetSortingLayer(IMeshObjectElement meshElement)
        {
            throw new NotImplementedException();
        }
    }
}