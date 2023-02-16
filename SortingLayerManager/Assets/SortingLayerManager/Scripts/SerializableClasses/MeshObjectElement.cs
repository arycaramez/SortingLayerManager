using UnityEngine;

namespace SortingLayerManager
{
    [System.Serializable]
    public class MeshObjectElement:IMeshObjectElement
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
}
