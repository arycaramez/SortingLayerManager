using UnityEngine;
using Anima2D;
using SortingLayerManager;

namespace SortingLayerManager
{
    [System.Serializable]
    public class MeshObjectElementForAnima2D : IMeshObjectElement
    {
        public string soTag;
        public GameObject meshObj;

        public MeshObjectElementForAnima2D(GameObject meshObj)
        {
            this.meshObj = meshObj;
        }

        public void SetSortingOrderID(int soID)
        {
            if (meshObj)
            {
                object renderObj = meshObj.GetComponent<SpriteMeshInstance>();
                if (renderObj == null) renderObj = meshObj.GetComponent<Renderer>();
                if (renderObj is SpriteMeshInstance)
                {
                    SpriteMeshInstance smi = (SpriteMeshInstance)renderObj;
                    smi.sortingOrder = soID;
                }
                else if (renderObj is Renderer)
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
}
